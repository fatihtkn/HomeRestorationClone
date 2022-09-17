using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITexturePainter 
{
     void PaintTexture(GameObject tool,Vector3 toolOffset);
     void PaintTexture();
}
