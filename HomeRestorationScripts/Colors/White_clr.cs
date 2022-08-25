using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class White_clr : MonoBehaviour,ISelectColor
{
    public Color white;

    public void SelectedColor()
    {
        ColorManagerSc.color_Manager.currentColor = white;
        ColorManagerSc.color_Manager.ColorPalette.SetActive(false);
        ImageRaycast.imageRaySc.controlTheRay = false;
       
    }
   
}
