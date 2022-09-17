using UnityEngine;

public class CrackPlasterManager : MonoSingleton<CrackPlasterManager>, IOnPainted
{
    public GameObject trowel;
    private TexturePainter texturePainter;
    
    private void Awake()
    {

        texturePainter = GetComponent<TexturePainter>();

    }

    private void Update()
    {
        bool controller = GameManager.state == GameManager.GameStates.Plastering & Input.GetMouseButton(0);

        if (controller)
        {
            texturePainter.PaintTexture(trowel, new Vector3(2f, 0, 0));

            if (texturePainter.IsWholeObjectPainted)
            {
                OnPainted();
            }
        }
       

    }


    public void OnPainted()
    {
        ConfettiManager.Instance.CreateConfetti();
        ButtonFunctionsManager.Instance.SetToWallPaintingButton.SetActive(true);
    }
}
