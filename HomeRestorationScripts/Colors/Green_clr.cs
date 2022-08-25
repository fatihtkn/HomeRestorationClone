using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green_clr : MonoBehaviour,ISelectColor
{
    public Color green;
    public void SelectedColor()
    {
        ColorManagerSc.color_Manager.currentColor = green;
        ColorManagerSc.color_Manager.ColorPalette.SetActive(false);
        ImageRaycast.imageRaySc.controlTheRay = false;
       
    }
}

