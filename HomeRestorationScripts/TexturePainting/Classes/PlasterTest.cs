using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasterTest : MonoBehaviour
{
    
    
    
    
    public static PlasterTheCrack plaster_sc;
    public GameObject trowel;
    private bool control;

    private float dirtAmountTotal, removedDirtAmount;
    private ITexturePainter texturePaint;

    

    private void Awake()
    {
        texturePaint = GetComponent<ITexturePainter>();
    }
    private void Start()
    {

        control = true;
        plaster_sc = GetComponent<PlasterTheCrack>();

        

    }

    private void Update()
    {
        


        if (GameManager.state == GameManager.GameStates.Plastering & Input.GetMouseButton(0))
        {
            
        }


        if (Mathf.RoundToInt(DirtPercentage() * 100) >= 89.5f & GameManager.state == GameManager.GameStates.Plastering & control)
        {


            ConfettiManager.confettiSc.CreateConfetti();
            ButtonFunctionsController.buttonManager.setToWallPaintingButton.SetActive(true);
            control = false;

        }

    }

    public float DirtPercentage()
    {

        return removedDirtAmount / dirtAmountTotal;
    }
    



    


}
