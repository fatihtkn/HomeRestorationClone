using UnityEngine;


public class TexturePainter : MonoBehaviour, ITexturePainter
{
    #region Scriptable Object Fields
    private Texture2D dirtBrush;
    private Texture2D GreenTextureBase;
    private Texture2D mainTexture;
    private Texture2D mainTextureReference;
    private GameManager.GameStates state;
    private LayerMask mask;
    public PaintableObject paintableObject;
    #endregion
    #region Color
    private static Color currentColor;
    public static Color CurrentColor => currentColor;
    #endregion


    private Texture2D cloneTexture;
    private float dirtAmountTotal, removedDirtAmount;
    private float percentage;
    private bool isObjectPainted;
    public bool IsWholeObjectPainted => isObjectPainted;

    #region Interfaces
    private IClearTexture mainTexCleaner;
    private IDirtCalculator totalDirtCalculation;
    private IResizeTex resizeTex;
    private IRayProvider rayProvider;
    private IRemovedDirtCalculator dirtPercentageCalculator;
    private IAreaController totalPaintedArea;
    #endregion

    #region Unity Functions
    private void Awake()
    {

        InitializeTheScriptableObjects();
        InterfaceInstances();

    }
    private void Start()
    {
        
        mainTexCleaner.ClearMainTexture(mainTexture, mainTextureReference);
        dirtAmountTotal = totalDirtCalculation.CalculateDirt(GreenTextureBase);
        resizeTex.ResizeTex(out cloneTexture, GreenTextureBase);

    }

    private void Update()
    {
        currentColor = ColorManagerSc.Instance.currentColor;
        percentage = dirtPercentageCalculator.RemovedDirtCalculate(removedDirtAmount, dirtAmountTotal);
        isObjectPainted = totalPaintedArea.PaintedArea(percentage, state);
       

    }
    #endregion

    #region Functions
    private void InterfaceInstances()
    {
        mainTexCleaner = new ClearMainTextureResponse();
        totalDirtCalculation = new TotalDirtCalculationResponse();
        resizeTex = new ResizeCloneTex();
        rayProvider = new MouseScreenRayProvider();
        dirtPercentageCalculator = new DirtPercentageCalculation();
        totalPaintedArea = new TotalPaintedAreaController();
        
    }


    private void InitializeTheScriptableObjects()
    {
        dirtBrush = paintableObject.dirtBrush;
        GreenTextureBase = paintableObject.mainTexGreen;
        mainTexture = paintableObject.mainTexture;
        mask = paintableObject.mask;
        state = paintableObject.desiredState;
        mainTextureReference = paintableObject.mainTexReference;

    }

    #endregion

    #region Interface Implementations
    public void PaintTexture(GameObject tool, Vector3 toolOffset)
    {
        if (Physics.Raycast(rayProvider.CreateRay(), out RaycastHit raycastHit, mask))
        {
            
            tool.transform.position = raycastHit.point + toolOffset;
            #region Texturecoordinate 
            Vector2 textureCoord = raycastHit.textureCoord;
            if (textureCoord == null) return;
           
            Renderer rend = raycastHit.collider.GetComponent<MeshRenderer>();
            Texture2D texture = rend.material.mainTexture as Texture2D;

            int pixelX = (int)(textureCoord.x * texture.width);
            int pixelY = (int)(textureCoord.y * texture.height);


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



                    texture.SetPixel(pixelXOffset + x,
                        pixelYOffset + y, currentColor);



                }

            }
            #endregion

            ProgressBar.Instance.SetBar(percentage);
            texture.Apply();
            cloneTexture.Apply();


        }
    }//with Tool

    public void PaintTexture()
    {
        if (Physics.Raycast(rayProvider.CreateRay(), out RaycastHit raycastHit, mask))
        {
            
            #region Texturecoordinate 
            Vector2 textureCoord = raycastHit.textureCoord;
            if (textureCoord == null) return;

            Renderer rend = raycastHit.collider.GetComponent<MeshRenderer>();
            Texture2D texture = rend.material.mainTexture as Texture2D;

            int pixelX = (int)(textureCoord.x * texture.width);
            int pixelY = (int)(textureCoord.y * texture.height);


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



                    texture.SetPixel(pixelXOffset + x,
                        pixelYOffset + y, currentColor);



                }

            }
            #endregion

            ProgressBar.Instance.SetBar(percentage);
            texture.Apply();
            cloneTexture.Apply();


        }
    }//without tool

    #endregion


}
