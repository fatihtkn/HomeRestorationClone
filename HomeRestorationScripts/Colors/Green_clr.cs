using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green_clr : MonoBehaviour,ISelectColor
{
    public Color green;
    public void SelectedColor()
    {
        ColorManagerSc.Instance.currentColor = green;
        ColorManagerSc.Instance.ColorPalette.SetActive(false);
        ImageRaycast.imageRaySc.controlTheRay = false;
       
    }
}

