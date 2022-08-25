using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_clr :MonoBehaviour, ISelectColor
{
    public Color red;
    public void SelectedColor()
    {
        ColorManagerSc.color_Manager.currentColor = red;
        ColorManagerSc.color_Manager.ColorPalette.SetActive(false);
        ImageRaycast.imageRaySc.controlTheRay = false;
        print("Red");

    }

    
}
