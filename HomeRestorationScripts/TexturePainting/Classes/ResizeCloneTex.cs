using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeCloneTex :  IResizeTex
{
    public Texture2D ResizeTex(out Texture2D cloneTexture,Texture2D textureBase)
    {
        cloneTexture = new Texture2D(textureBase.width, textureBase.height);
        cloneTexture.SetPixels(textureBase.GetPixels());
        cloneTexture.Apply();
        return cloneTexture;
    }
}
