using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private GameObject startUI;
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject mop;
    [SerializeField] private GameObject virtualCam1;
     private Animator handAnimation;

    private void Start()
    {

        handAnimation = startUI.GetComponentInChildren<Animator>();
        handAnimation.SetBool("play", true);
        
        
    }
    
    public void StartUp()
    {
        startUI.SetActive(false);
        if (SceneManager.GetActiveScene().name == "Level2")
        {
            
            StartCoroutine(Delay());
        }
        else
        {
            GameManager.state = GameManager.GameStates.Started;
            StartCoroutine(Delay());
        }
        
        startPanel.SetActive(false);
        CameraManager.cameraManagerScript.SetCamera2On();
        
        
        handAnimation.SetBool("play", false);
        
    }
    

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2f);
        
        if (ToolManager.toolmanagerSc.mop != null)
        {
            GameManager.state = GameManager.GameStates.Painting;
            ToolManager.toolmanagerSc.SetMopActive(true);
        }
        if(ToolManager.toolmanagerSc.silicon_gun != null)
        {
            ToolManager.toolmanagerSc.SetGunActive(true);
            GameManager.state = GameManager.GameStates.Siliconing;
        }
        
    }





}
