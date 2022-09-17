using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDirtCalculator 
{
     float CalculateDirt(Texture2D cloneTextureBase);
     float CalculateDirt(Texture2D cloneTextureBase,Texture2D cloneTex2);



}
