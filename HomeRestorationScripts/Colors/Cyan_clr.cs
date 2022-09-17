using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cyan_clr : MonoBehaviour,ISelectColor
{
    public Color cyan;
    public void SelectedColor()
    {
        ColorManagerSc.Instance.currentColor = cyan;
        ColorManagerSc.Instance.ColorPalette.SetActive(false);
        ImageRaycast.imageRaySc.controlTheRay = false;

    }
}
