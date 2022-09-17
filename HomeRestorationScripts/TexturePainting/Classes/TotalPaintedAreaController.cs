using UnityEngine;


 public class TotalPaintedAreaController :IAreaController
 {
    
     public bool PaintedArea(float percentage,GameManager.GameStates desiredState)
     {
        
         if (Mathf.RoundToInt(percentage * 100) >= 89.5f & GameManager.state == desiredState)
         {

            return true;
            
         }
        return false;
     }

   
}

