using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;



public class DirtClearManager : MonoBehaviour
{
    [SerializeField] private Texture2D dirtMaskTextureBase;
    [SerializeField] private Texture2D dirtBrush;
    [SerializeField] private Material material;
    [SerializeField] private TextMeshProUGUI uiText;
    [SerializeField] private GameObject confetti;

    private Texture2D dirtMaskTexture;
    private Texture2D first;
    private Texture2D second;
    private float dirtAmountTotal;
    private float dirtAmount;
    private Vector2Int lastPaintPixelPosition;
    private float removedDirtAmount;
    public static bool activeScene;
    public Canvas canvas;

    
    
    private void Awake()
    {
        dirtMaskTexture = new Texture2D(dirtMaskTextureBase.width, dirtMaskTextureBase.height);
        dirtMaskTexture.SetPixels(dirtMaskTextureBase.GetPixels());
        dirtMaskTexture.Apply();
        material.SetTexture("_DirtMask", dirtMaskTexture);

        
        dirtAmountTotal = 0f;
        for (int x = 0; x < dirtMaskTextureBase.width; x++)
        {
            for (int y = 0; y < dirtMaskTextureBase.height; y++)
            {
                dirtAmountTotal += dirtMaskTextureBase.GetPixel(x, y).g;
            }
        }
        dirtAmount = dirtAmountTotal;
        removedDirtAmount = 0f;
        print(dirtAmountTotal);

        

    }

    private void Update()
    {
        

        PaintTexture();
        if (Mathf.RoundToInt(DirtAmountFunc()*100)>=98.5f & GameManager.state == GameManager.GameStates.Painting)
        {
            
            confetti.SetActive(true);
            GameManager.state = GameManager.GameStates.SelectingRoomTemplate;
            ImageRaycast.imageRaySc.controlTheRay = true;

        }

        

    }
    private void PaintTexture()
    {
        
        if (Input.GetMouseButton(0)&GameManager.state==GameManager.GameStates.Painting)
        {
           

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit raycastHit))
            {
                ToolManager.toolmanagerSc.mop.transform.position = raycastHit.point;

                
               Vector2 textureCoord = raycastHit.textureCoord;
                int pixelX = (int)(textureCoord.x * dirtMaskTexture.width);
                int pixelY = (int)(textureCoord.y * dirtMaskTexture.height);
                if (textureCoord != null) print(textureCoord);
               
                //DirtBrush
                int pixelXOffset = pixelX - (dirtBrush.width / 2);
                int pixelYOffset = pixelY - (dirtBrush.height / 2);
                

                for (int x = 0; x < dirtBrush.width; x++)
                {
                    for (int y = 0; y < dirtBrush.height; y++)
                    {
                        Color pixelDirt = dirtBrush.GetPixel(x, y);
                        Color pixelDirtMask = dirtMaskTexture.GetPixel(pixelXOffset + x, pixelYOffset + y);

                        float removedAmount = pixelDirtMask.g - (pixelDirtMask.g * pixelDirt.g);
                        dirtAmount -= removedAmount;
                        removedDirtAmount += removedAmount;

                        dirtMaskTexture.SetPixel(
                            pixelXOffset + x,
                            pixelYOffset + y,
                            new Color(0, pixelDirtMask.g * pixelDirt.g, 0)
                        );
                    }
                }
                

                dirtMaskTexture.Apply();
                //uiText.text = Mathf.RoundToInt(GetDirtAmount() * 100f) + "%";
            }
        }
        ProgressBar.progressbarSc.SetBar(DirtAmountFunc());
    }
    //public float GetDirtAmount()
    //{
    //    return this.dirtAmount / dirtAmountTotal;
    //}
    public float DirtAmountFunc()
    {
        
        return removedDirtAmount/dirtAmountTotal;
    }
    
}
