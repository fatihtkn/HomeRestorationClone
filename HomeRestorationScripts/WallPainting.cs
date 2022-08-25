using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPainting : MonoBehaviour
{
    [SerializeField] private Texture2D wallbaseTexture;
    [SerializeField] private LayerMask mask;
    [SerializeField] private Texture2D dirtBrush;
    [SerializeField] private Texture2D mainTexture;
    [SerializeField] private Texture2D mainTextureReference;
    [SerializeField] private Texture2D CrackBaseTex;

    private bool control;
    public Vector3 paintbrushOffset;
    public bool startPaint;
    public static WallPainting walpaint_sc;
    private Texture2D wallCloneTex;
    private Texture2D totalPixelCount;
    private float dirtAmount, removedDirtAmount,dirtAmountTotal;
    public Color color;
    

    private void Awake()
    {
        walpaint_sc = GetComponent<WallPainting>();
        //color = ColorManagerSc.color_Manager.currentColor;
        control = true;
    }
    private void Start()
    {
        

        mainTexture.SetPixels(mainTextureReference.GetPixels());
        mainTexture.Apply();

        totalPixelCount = new Texture2D((wallbaseTexture.width + CrackBaseTex.width)/2, (wallbaseTexture.height + CrackBaseTex.height)/2);


        wallCloneTex = new Texture2D(totalPixelCount.width, totalPixelCount.height);
        wallCloneTex.SetPixels(wallbaseTexture.GetPixels());
        wallCloneTex.Apply();

        for (int x = 0; x < totalPixelCount.width; x++)
        {
            for (int y = 0; y < totalPixelCount.height; y++)
            {
                dirtAmountTotal += totalPixelCount.GetPixel(x, y).g;
            }
        }
        dirtAmount = dirtAmountTotal;
        removedDirtAmount = 0f;
    }


    private void Update()
    {
        if (Mathf.RoundToInt(DirtAmountFunc() * 100) >= 93f&GameManager.state==GameManager.GameStates.WallPainting&control)
        {

            
            ConfettiManager.confettiSc.CreateConfetti();
            StartCoroutine(Cooldwon());
            
            control = false;
            

        }
        if(GameManager.state == GameManager.GameStates.WallPainting & Input.GetMouseButton(0))
        {
            
             if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit ray, mask))
             {
                ToolManager.toolmanagerSc.paintbrush.transform.position = ray.point+paintbrushOffset;
                
                 Vector2 textureCoord = ray.textureCoord;
                 Renderer rend = ray.collider.GetComponent<Renderer>();
                 Texture2D tex = rend.material.mainTexture as Texture2D;

                 int pixelX = (int)(textureCoord.x * tex.width);
                 int pixelY = (int)(textureCoord.y * tex.height);

                 if (textureCoord == null)
                 {
                     return;
                 }


                 int pixelXOffset = pixelX - (dirtBrush.width / 2);
                 int pixelYOffset = pixelY - (dirtBrush.height / 2);


                 for (int x = 0; x < dirtBrush.width; x++)
                 {
                     for (int y = 0; y < dirtBrush.height; y++)
                     {

                         Color pixelDirt = dirtBrush.GetPixel(x, y);
                         Color pixelDirtMask = wallCloneTex.GetPixel(pixelXOffset + x, pixelYOffset + y);

                         float removedAmount = pixelDirtMask.g - (pixelDirtMask.g * pixelDirt.g);
                         dirtAmount -= removedAmount;
                         removedDirtAmount += removedAmount;

                         wallCloneTex.SetPixel(
                             pixelXOffset + x,
                             pixelYOffset + y,
                             new Color(0, pixelDirtMask.g * pixelDirt.g, 0));



                         tex.SetPixel(pixelXOffset + x,
                             pixelYOffset + y,ColorManagerSc.color_Manager.currentColor );


                     }  

                 }
                 tex.Apply();
                wallCloneTex.Apply();
                 ProgressBar.progressbarSc.SetBar(DirtAmountFunc());
             }
            

        }
        
        

    }

    public float DirtAmountFunc()
    {

        return removedDirtAmount / dirtAmountTotal;
    }
    private void PaintAllPixels()
    {
        for (int i = 0; i < mainTexture.width; i++)
        {
            for (int j = 0; j < mainTexture.height; j++)
            {
               mainTexture.SetPixel(i, j, color);
            }
        }
    }
    IEnumerator Cooldwon()
    {
        yield return new WaitForSeconds(2f);
        ButtonFunctionsController.buttonManager.restartButton.SetActive(true);
    }
}
