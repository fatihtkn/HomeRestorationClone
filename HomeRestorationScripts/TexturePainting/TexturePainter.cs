using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ClearMainTextureResponse),typeof(TotalDirtCalculationResponse),typeof(ResizeCloneTex))]
[RequireComponent(typeof(MouseScreenRayProvider),typeof(DirtPercentageCalculation),typeof(TotalPaintedAreaController))]
public class TexturePainter : MonoBehaviour,ITexturePainter
{
    private Texture2D dirtBrush;
    private Texture2D cloneTextureBase;
    private Texture2D mainTexture;
    private Texture2D mainTextureReference;
    private Texture2D wallGreenTex;

    private Texture2D cloneTexture;
    private LayerMask mask;
    public static Color currentColor;

    public PaintableObject paintableObject;

    private float dirtAmountTotal, removedDirtAmount;
    private float percentage;
    private GameManager.GameStates state;

    private IClearTexture mainTexCleaner;
    private IDirtCalculator totalDirtCalculation;
    private IResizeTex resizeTex;
    private IRayProvider rayProvider;
    private IRemovedDirtCalculator dirtPercentageCalculator;
    private IAreaController totalPaintedArea;

    
    
    private void Awake()
    {

        StartUp();
        mainTexCleaner = GetComponent<IClearTexture>();
        totalDirtCalculation = GetComponent<IDirtCalculator>();
        resizeTex = GetComponent<IResizeTex>();
        rayProvider = GetComponent<IRayProvider>();
        dirtPercentageCalculator = GetComponent<IRemovedDirtCalculator>();
        totalPaintedArea = GetComponent<IAreaController>();
    }
    private void Start()
    {

        mainTexCleaner.ClearMainTexture(mainTexture,mainTextureReference);
        dirtAmountTotal = totalDirtCalculation.CalculateDirt(cloneTextureBase);
        resizeTex.ResizeTex(out cloneTexture, cloneTextureBase);

    }

    private void Update()
    {
        currentColor = ColorManagerSc.color_Manager.currentColor;
        percentage = dirtPercentageCalculator.RemovedDirtCalculate(removedDirtAmount, dirtAmountTotal);
        totalPaintedArea.PaintedArea(percentage, state);
    }

    


    private void StartUp()
    {
        dirtBrush = paintableObject.dirtBrush;
        cloneTextureBase = paintableObject.mainTexGreen;
        mainTexture = paintableObject.mainTexture;
        mask = paintableObject.mask;
        state = paintableObject.desiredState;
        mainTextureReference = paintableObject.mainTexReference;
        
    }

    

    public void PaintTexture(GameObject tool,Vector3 toolOffset)//Interface Implementation
    {
        if (Physics.Raycast(rayProvider.CreateRay(), out RaycastHit raycastHit, mask))
        {
            tool.transform.position = raycastHit.point +toolOffset;
            #region Texturecoordinate 
            Vector2 textureCoord = raycastHit.textureCoord;
            if (textureCoord == null)
            {
                return;
            }
            Renderer rend = raycastHit.collider.GetComponent<MeshRenderer>();
            Texture2D tex = rend.material.mainTexture as Texture2D;

            int pixelX = (int)(textureCoord.x * tex.width);
            int pixelY = (int)(textureCoord.y * tex.height);

            
            #endregion



            #region PaintBrush
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
            #endregion

            ProgressBar.progressbarSc.SetBar(percentage);
            tex.Apply();
            cloneTexture.Apply();


        }
    }
}
