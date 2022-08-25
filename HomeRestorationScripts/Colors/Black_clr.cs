using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Black_clr : MonoBehaviour,ISelectColor
{
    public Color black;
    public void SelectedColor()
    {
        ColorManagerSc.color_Manager.currentColor = black;
        ColorManagerSc.color_Manager.ColorPalette.SetActive(false);
        ImageRaycast.imageRaySc.controlTheRay = false;

    }
}
