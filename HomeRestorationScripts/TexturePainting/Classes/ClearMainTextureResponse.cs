using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearMainTextureResponse : MonoBehaviour, IClearTexture
{
    public void ClearMainTexture(Texture2D mainTexture,Texture2D mainTexReference)
    {
        if (mainTexture != null)
        {
            mainTexture.SetPixels(mainTexReference.GetPixels());
            mainTexture.Apply();
            //for (int i = 0; i < mainTexture.width; i++)
            //{
            //    for (int j = 0; j < mainTexture.height; j++)
            //    {
            //        mainTexture.SetPixel(i, j, Color.clear);
            //    }
            //}
            //mainTexture.Apply();
        }
    }
}
