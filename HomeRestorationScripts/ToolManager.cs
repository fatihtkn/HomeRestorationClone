using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolManager :MonoSingleton<ToolManager>
{
    public GameObject mop;
    public GameObject silicon_gun;
    public GameObject paintbrush;
    
    public void SetMopActive(bool control)
    {
        if (mop != null)
        {
            mop.SetActive(control);
        }
        
    }
    public void SetGunActive(bool control)
    {
        if (silicon_gun != null)
        {
            silicon_gun.SetActive(control);
        }
    }
    public void SetBrushActive(bool control)
    {
        if (paintbrush != null)
        {
            paintbrush.SetActive(control);
        }
    }

}
