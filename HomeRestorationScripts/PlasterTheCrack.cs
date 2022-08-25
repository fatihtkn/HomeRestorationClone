using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasterTheCrack : MonoBehaviour
{
    
    public Texture2D dirtBrush;
    public Texture2D cloneTextureBase;
    public Texture2D transparentTex;
                     private Texture2D cloneTexture;
    [SerializeField] private LayerMask mask;
    public GameObject trowel;
    public static Color currentColor;
    public static PlasterTheCrack plaster_sc;
    [SerializeField]private Material mat;
    private bool control;
    public Color test;

    private float dirtAmountTotal, dirtAmount, removedDirtAmount;

   
    private void Start()
    {
        
        control = true;
        
        
        plaster_sc = GetComponent<PlasterTheCrack>();

        ClearMainTexture();

        SetCloneTexPixels();

        CalculateDirtAmount();
        
    }

    private void Update()
    {
        PaintTexture();

        if (Mathf.RoundToInt(DirtAmountFunc() * 100) >= 89.5f & GameManager.state == GameManager.GameStates.Plastering&control)
        {


            ConfettiManager.confettiSc.CreateConfetti();
            ButtonFunctionsController.buttonManager.setToWallPaintingButton.SetActive(true);
            control = false;
            
        }

    }

    public float DirtAmountFunc()
    {

        return removedDirtAmount / dirtAmountTotal;
    }
    public void SetCloneTexPixels()
    {
        cloneTexture = new Texture2D(cloneTextureBase.width, cloneTextureBase.height);
        cloneTexture.SetPixels(cloneTextureBase.GetPixels());
        cloneTexture.Apply();
    }

    private void ClearMainTexture()
    {
        if (transparentTex != null)
        {

            for (int i = 0; i < transparentTex.width; i++)
            {
                for (int j = 0; j < transparentTex.height; j++)
                {
                    transparentTex.SetPixel(i, j, Color.clear);
                }
            }
            transparentTex.Apply();
        }
            

       
    }
    private void CalculateDirtAmount()
    {
        for (int x = 0; x < cloneTextureBase.width; x++)
        {
            for (int y = 0; y < cloneTextureBase.height; y++)
            {
                dirtAmountTotal += cloneTextureBase.GetPixel(x, y).g;
            }
        }
        dirtAmount = dirtAmountTotal;
        removedDirtAmount = 0f;
    }
    private void PaintTexture()
    {
        currentColor = ColorManagerSc.color_Manager.currentColor;
        if (GameManager.state == GameManager.GameStates.Plastering)
        { 


            if (Input.GetMouseButton(0))
            {

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit raycastHit,mask))
                {
                    
                    trowel.transform.position = raycastHit.point+new Vector3(2,0,0);
                    Vector2 textureCoord = raycastHit.textureCoord;
                    Renderer rend = raycastHit.collider.GetComponent<MeshRenderer>();
                    Texture2D tex = rend.material.mainTexture as Texture2D;

                    int pixelX = (int)(textureCoord.x * tex.width);
                    int pixelY = (int)(textureCoord.y * tex.height);

                    if (textureCoord == null)
                    {
                        return;
                    }




                    //DirtBrush
                    int pixelXOffset = pixelX - (dirtBrush.width / 2);
                    int pixelYOffset = pixelY - (dirtBrush.height / 2);


                    for (int x = 0; x < dirtBrush.width; x++)
                    {
                        for (int y = 0; y < dirtBrush.height; y++)
                        {
                            Color pixelDirt = dirtBrush.GetPixel(x, y);
                            Color pixelDirtMask = cloneTexture.GetPixel(pixelXOffset + x, pixelYOffset + y);

                            float removedAmount = pixelDirtMask.g - (pixelDirtMask.g * pixelDirt.g);
                            removedDirtAmount += removedAmount;

                            cloneTexture.SetPixel(
                                pixelXOffset + x,
                                pixelYOffset + y,
                                new Color(0, pixelDirtMask.g * pixelDirt.g, 0));



                            tex.SetPixel(pixelXOffset + x,
                                pixelYOffset + y, currentColor);
                            
                            

                        }

                    }

                    ProgressBar.progressbarSc.SetBar(DirtAmountFunc());
                    tex.Apply();
                    cloneTexture.Apply();


                }
            }

        }

    }
}
