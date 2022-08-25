using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yellow_clr : MonoBehaviour,ISelectColor
{
    public Color yellow;
    public void SelectedColor()
    {
        ColorManagerSc.color_Manager.currentColor = yellow;
        ColorManagerSc.color_Manager.ColorPalette.SetActive(false);
        ImageRaycast.imageRaySc.controlTheRay = false;

    }
}
