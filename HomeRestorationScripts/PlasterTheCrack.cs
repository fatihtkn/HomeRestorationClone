using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasterTheCrack : MonoBehaviour,IOnPainted
{
    public GameObject trowel;
    public static PlasterTheCrack Instance;
    private ITexturePainter texturePainter;

    private void Awake()
    {
        
        texturePainter = GetComponent<ITexturePainter>();

    }
    private void Start()
    {
        if (Instance == null)
        {
            Instance = GetComponent<PlasterTheCrack>();
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        bool controller = GameManager.state == GameManager.GameStates.Plastering & Input.GetMouseButton(0);

        if (controller)
        {
            texturePainter.PaintTexture(trowel, new Vector3(2f, 0, 0));
        }

    }


    public void OnPainted() //Interface Implementation
    {
        ConfettiManager.confettiSc.CreateConfetti();
        ButtonFunctionsController.buttonManager.setToWallPaintingButton.SetActive(true);
    }
}
