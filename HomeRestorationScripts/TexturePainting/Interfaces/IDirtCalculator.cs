using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDirtCalculator 
{
    public float CalculateDirt(Texture2D cloneTextureBase);
    public float CalculateDirt(Texture2D cloneTextureBase,Texture2D cloneTex2);



}
