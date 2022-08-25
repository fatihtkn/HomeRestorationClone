using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purple_clr : MonoBehaviour,ISelectColor
{
    public Color purple;
    public void SelectedColor()
    {
        ColorManagerSc.color_Manager.currentColor = purple;
        ColorManagerSc.color_Manager.ColorPalette.SetActive(false);
        ImageRaycast.imageRaySc.controlTheRay = false;

    }
}
