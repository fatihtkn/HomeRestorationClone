using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IResizeTex 
{
    Texture2D ResizeTex(out Texture2D cloneTex,Texture2D textureBase);
}
