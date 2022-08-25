using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green2_clr : MonoBehaviour,ISelectColor
{
    public Color green2;
    public void SelectedColor()
    {
        ColorManagerSc.color_Manager.currentColor = green2;
        ColorManagerSc.color_Manager.ColorPalette.SetActive(false);
        ImageRaycast.imageRaySc.controlTheRay = false;

    }
}
