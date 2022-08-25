using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private Image pBar;
    [SerializeField]private TextureManager textureManager;
    public static ProgressBar progressbarSc;

    private void Awake()
    {
        progressbarSc = GetComponent<ProgressBar>();
    }
    private void Start()
    {
        pBar = GetComponent<Image>();
        pBar.fillAmount = 0;
        
    }
    private void Update()
    {
        //dirtAmount = textureManager.DirtAmountFunc();
        //pBar.fillAmount = dirtAmount; 
        
    }
    public void SetBar(float dirtamount)
    {
        pBar.fillAmount = dirtamount;
        //print(dirtamount);
        if (GameManager.state == GameManager.GameStates.Painting& dirtamount >= 0.985f)
        {
             pBar.fillAmount = 1.00f;
        }
        if(GameManager.state == GameManager.GameStates.Siliconing& dirtamount >= 0.94f)
        {
           
             pBar.fillAmount = 1.00f;
        }
        
        if (GameManager.state == GameManager.GameStates.Plastering& dirtamount >= 0.895f)
        {
            
              pBar.fillAmount = 1.00f;
        }
        if (GameManager.state == GameManager.GameStates.WallPainting& dirtamount >= 0.93f)
        {
            
              pBar.fillAmount = 1.00f;
        }
        
    }
    public void ResetThepBar()
    {
        pBar.fillAmount = 0f;
    }
    

}
