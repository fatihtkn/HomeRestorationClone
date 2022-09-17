using UnityEngine;


public class GameManager : MonoBehaviour
{
   
    public static GameStates state;
    
    
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
