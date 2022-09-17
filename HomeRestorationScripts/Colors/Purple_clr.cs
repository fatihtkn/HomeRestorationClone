using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purple_clr : MonoBehaviour,ISelectColor
{
    public Color purple;
    public void SelectedColor()
    {
        ColorManagerSc.Instance.currentColor = purple;
        ColorManagerSc.Instance.ColorPalette.SetActive(false);
        ImageRaycast.imageRaySc.controlTheRay = false;

    }
}
