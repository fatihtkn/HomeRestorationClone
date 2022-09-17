using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPaintManager : MonoSingleton<WallPaintManager>, IOnPainted
{
    private TexturePainter texturePainter;

    private void Start()
    {
        texturePainter = GetComponent<TexturePainter>();
    }
    private void Update()
    {
        
        if(GameManager.state == GameManager.GameStates.WallPainting & Input.GetMouseButton(0))
        {

            texturePainter.PaintTexture(ToolManager.Instance.paintbrush,new Vector3(1f,-2.3f,-0.7f));
            
            
            if (texturePainter.IsWholeObjectPainted)
            {
                OnPainted();
            }
        }

    }
    
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(2f);
        ButtonFunctionsManager.Instance.RestartButton.SetActive(true);
    }

    public void OnPainted()//Interface Implementation
    {
        ConfettiManager.Instance.CreateConfetti();
        StartCoroutine(Timer());
    }
}
