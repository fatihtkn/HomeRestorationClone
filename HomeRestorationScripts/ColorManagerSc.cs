using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManagerSc : MonoBehaviour
{   
    public  Color currentColor;
    public GameObject ColorPalette;
    public static ColorManagerSc color_Manager;
    public Color colorRef;

    private void Awake()
    {

        
    }
    private void Start()
    {
        color_Manager=GetComponent<ColorManagerSc>();
    }
}
