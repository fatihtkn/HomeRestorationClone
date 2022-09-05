using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalDirtCalculationResponse : MonoBehaviour, IDirtCalculator
{
    public float CalculateDirt(Texture2D cloneTextureBase)
    {
        float dirtamountTotal = 0;

        for (int x = 0; x < cloneTextureBase.width; x++)
        {
            for (int y = 0; y < cloneTextureBase.height; y++)
            {
                dirtamountTotal+= cloneTextureBase.GetPixel(x, y).g;
                
            }
        }
        return dirtamountTotal;
    }
    public float CalculateDirt(Texture2D cloneTextureBase,Texture2D cloneTexBase)
    {
        Texture2D totalGreenArea = new Texture2D((cloneTextureBase.width + cloneTexBase.width)/2 , (cloneTextureBase.height + cloneTexBase.height)/2 );
        float dirtamountTotal = 0;

        for (int x = 0; x < totalGreenArea.width; x++)
        {
            for (int y = 0; y < totalGreenArea.height; y++)
            {
                dirtamountTotal += totalGreenArea.GetPixel(x, y).g;

            }
        }
        return dirtamountTotal;
    }
}
