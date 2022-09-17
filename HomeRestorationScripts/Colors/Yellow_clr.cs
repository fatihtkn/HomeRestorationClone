using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yellow_clr : MonoBehaviour,ISelectColor
{
    public Color yellow;
    public void SelectedColor()
    {
        ColorManagerSc.Instance.currentColor = yellow;
        ColorManagerSc.Instance.ColorPalette.SetActive(false);
        ImageRaycast.imageRaySc.controlTheRay = false;

    }
}
