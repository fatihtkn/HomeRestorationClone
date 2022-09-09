using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPainting : MonoBehaviour, IOnPainted
{
    
    public static WallPainting Instance;
    private ITexturePainter texturePaint;
    

    private void Awake()
    {
        
        if (Instance == null)
        {
            Instance = GetComponent<WallPainting>();
        }
        else
        {
            Destroy(this);
        }
        texturePaint = GetComponent<ITexturePainter>();
        
    }
    private void Update()
    {
        
        if(GameManager.state == GameManager.GameStates.WallPainting & Input.GetMouseButton(0))
        {

            texturePaint.PaintTexture(ToolManager.toolmanagerSc.paintbrush,new Vector3(1f,-2.3f,-0.7f));
        }

    }
    
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(2f);
        ButtonFunctionsController.buttonManager.restartButton.SetActive(true);
    }

    public void OnPainted()//Interface Implementation
    {
        ConfettiManager.confettiSc.CreateConfetti();
        StartCoroutine(Timer());
    }
}
