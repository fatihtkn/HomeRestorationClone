using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class White_clr : MonoBehaviour,ISelectColor
{
    public Color white;

    public void SelectedColor()
    {
        ColorManagerSc.Instance.currentColor = white;
        ColorManagerSc.Instance.ColorPalette.SetActive(false);
        ImageRaycast.imageRaySc.controlTheRay = false;
       
    }
   
}
