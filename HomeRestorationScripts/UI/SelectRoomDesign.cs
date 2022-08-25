using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class SelectRoomDesign : MonoBehaviour
{
     public  GameObject plus_image,roomSelectPanel;
    public static SelectRoomDesign roomDesignsc;
    private float sayi = 2f;


    private void Awake()
    {
        roomDesignsc = this.gameObject.GetComponent<SelectRoomDesign>();
    }
    private void Start()
    {
        
    }
   

    private void Update()
    {
        if(GameManager.state == GameManager.GameStates.SelectingRoomTemplate)
        {
            
            ToolManager.toolmanagerSc.SetMopActive(false);

            Counter();

        }
        
    }

    public void SetActiveSelectPanel() //Button
    {
        
        roomSelectPanel.SetActive(true);

    }
   

   public  void  SetSprites()
   {
        GameManager.state = GameManager.GameStates.Level1Finished;
        roomSelectPanel.SetActive(false);
        plus_image.SetActive(false);
        
    }
    private void Counter()
    {
        CameraManager.cameraManagerScript.SetCamera1On();
        sayi -= Time.deltaTime;
        if (sayi <= 0)
        {
            plus_image.SetActive(true);
        }
    }

}
