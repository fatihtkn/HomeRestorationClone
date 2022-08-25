using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctionsController : MonoBehaviour
{
    [SerializeField] private GameObject nextLevelButton;
    public GameObject setToPlasterButton;
    public GameObject setToWallPaintingButton;
    public GameObject restartButton;
    private float timer;
    public static ButtonFunctionsController buttonManager;


    
    


    private void Awake()
    {

        timer = 2f;
    }
    private void Start()
    {
        buttonManager = GetComponent<ButtonFunctionsController>();
    }
    private void Update()
    {
        if (GameManager.state == GameManager.GameStates.Level1Finished)
        {
            timer -= Time.deltaTime;
            if(timer<=0)
            nextLevelButton.SetActive(true);
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Level2");
        GameManager.state = GameManager.GameStates.Level2Started;
    }
    public void SetStateToPlaster()
    {
        PlasterTheCrack.plaster_sc.trowel.SetActive(true);
        PlasterTheCrack.plaster_sc.GetComponent<MeshCollider>().enabled = true;
        GameManager.state = GameManager.GameStates.Plastering;
        ProgressBar.progressbarSc.ResetThepBar();
        setToPlasterButton.SetActive(false);
        

    }
    public void SetStateToWallPaint()
    {
        
        setToWallPaintingButton.SetActive(false);
        WallPainting.walpaint_sc.GetComponent<MeshCollider>().enabled = true;
        GameManager.state = GameManager.GameStates.SelectingColor;
        ImageRaycast.imageRaySc.controlTheRay = true;
        PlasterTheCrack.plaster_sc.trowel.SetActive(false);
        PlasterTheCrack.plaster_sc.enabled = false;
        ColorManagerSc.color_Manager.ColorPalette.SetActive(true);
        CameraManager.cameraManagerScript.SetCamera3On();
        ToolManager.toolmanagerSc.SetBrushActive(true);



    }
    public void RestartTheGame()
    {
        SceneManager.LoadScene("Level1");
        GameManager.state = GameManager.GameStates.Started;
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1.5f);
        CameraManager.cameraManagerScript.SetCamera3On();
        
    }
}