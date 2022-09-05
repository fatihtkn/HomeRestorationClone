using System.Collections;
using System.Collections.Generic;
using UnityEngine;



 public class TotalPaintedAreaController : MonoBehaviour, IAreaController
 {
      private bool control;
     private IOnPainted onPainted;
     private void Awake()
     {
        control = true;
        onPainted = GetComponent<IOnPainted>();


     }
     public void PaintedArea(float percentage,GameManager.GameStates desiredState)
     {
         if (Mathf.RoundToInt(percentage * 100) >= 89.5f & GameManager.state == desiredState & control)
         {

            onPainted.OnPainted();
             control = false;

         }
     }
 }

