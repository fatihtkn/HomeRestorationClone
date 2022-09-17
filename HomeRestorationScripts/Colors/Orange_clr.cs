using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orange_clr  : MonoBehaviour,ISelectColor
{
    public Color orange;
    public void SelectedColor()
    {
        ColorManagerSc.Instance.currentColor = orange;
        ColorManagerSc.Instance.ColorPalette.SetActive(false);
        ImageRaycast.imageRaySc.controlTheRay = false;

    }
}
