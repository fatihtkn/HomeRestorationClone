using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   
    public static GameStates state;
    private void Awake()
    {
        
    }

    private void Start()
    {
        
    }
    private void Update()
    {


        print("Þuanki state " + state);

        
    }
        
    
    public enum GameStates
    {
        WaitingForFirstTouch,
        Started,
        Painting,
        SelectingRoomTemplate,
        Level1Finished,
        Level2Started,
        Siliconing,
        Plastering,
        SelectingColor,
        WallPainting,
        GameOver



    }
    
    
   
}
