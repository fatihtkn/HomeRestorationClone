using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Black_clr : MonoBehaviour,ISelectColor
{
    public Color black;
    public void SelectedColor()
    {
        ColorManagerSc.Instance.currentColor = black;
        ColorManagerSc.Instance.ColorPalette.SetActive(false);
        ImageRaycast.imageRaySc.controlTheRay = false;

    }
}
