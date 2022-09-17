using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_clr :MonoBehaviour, ISelectColor
{
    public Color red;
    public void SelectedColor()
    {
        ColorManagerSc.Instance.currentColor = red;
        ColorManagerSc.Instance.ColorPalette.SetActive(false);
        ImageRaycast.imageRaySc.controlTheRay = false;
        print("Red");

    }

    
}
