using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pink_clr : MonoBehaviour,ISelectColor
{
    public Color pink;
    public void SelectedColor()
    {
        ColorManagerSc.color_Manager.currentColor = pink;
        ColorManagerSc.color_Manager.ColorPalette.SetActive(false);
        ImageRaycast.imageRaySc.controlTheRay = false;
        print("Pink");
    }

    
}
