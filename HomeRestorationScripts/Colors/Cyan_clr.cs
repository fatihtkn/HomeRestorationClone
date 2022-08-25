using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cyan_clr : MonoBehaviour,ISelectColor
{
    public Color cyan;
    public void SelectedColor()
    {
        ColorManagerSc.color_Manager.currentColor = cyan;
        ColorManagerSc.color_Manager.ColorPalette.SetActive(false);
        ImageRaycast.imageRaySc.controlTheRay = false;

    }
}
