using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctionsManager : MonoSingleton<ButtonFunctionsManager>
{
    [SerializeField] private GameObject nextLevelButton;
    [SerializeField] private GameObject setToPlasterButton;
    [SerializeField] private GameObject setToWallPaintingButton;
    [SerializeField] private GameObject restartButton;
    public GameObject SetToPlasterButton => setToPlasterButton;
    public GameObject SetToWallPaintingButton => setToWallPaintingButton;
    public GameObject RestartButton => restartButton;


    

    private float timer;
    
    private void Awake()
    {

        timer = 2f;
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
        CrackPlasterManager.Instance.trowel.SetActive(true);
        CrackPlasterManager.Instance.GetComponent<MeshCollider>().enabled = true;

        GameManager.state = GameManager.GameStates.Plastering;
        ProgressBar.Instance.ResetThepBar();

        setToPlasterButton.SetActive(false);
        ConfettiManager.Instance.Confetti.SetActive(false);
        

    }
    public void SetStateToWallPaint()
    {
        
        setToWallPaintingButton.SetActive(false);
        WallPaintManager.Instance.GetComponent<MeshCollider>().enabled = true;

        GameManager.state = GameManager.GameStates.SelectingColor;
        ImageRaycast.imageRaySc.controlTheRay = true;

        CrackPlasterManager.Instance.trowel.SetActive(false);
        CrackPlasterManager.Instance.enabled = false;

        ColorManagerSc.Instance.ColorPalette.SetActive(true);
        CameraManager.cameraManagerScript.SetCamera3On();

        ToolManager.Instance.SetBrushActive(true);
        ConfettiManager.Instance.Confetti.SetActive(false);


    }
    public void RestartTheGame()
    {
        SceneManager.LoadScene("Level1");
        GameManager.state = GameManager.GameStates.Started;
    }
   
}