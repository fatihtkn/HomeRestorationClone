using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orange_clr  : MonoBehaviour,ISelectColor
{
    public Color orange;
    public void SelectedColor()
    {
        ColorManagerSc.color_Manager.currentColor = orange;
        ColorManagerSc.color_Manager.ColorPalette.SetActive(false);
        ImageRaycast.imageRaySc.controlTheRay = false;

    }
}
