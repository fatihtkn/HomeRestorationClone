using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1 : MonoBehaviour,ISelectRoom
{
    [SerializeField] private GameObject roomItems_1;

    public void Interact()
    {
        
        roomItems_1.SetActive(true);
        SelectRoomDesign.roomDesignsc.SetSprites();
        ImageRaycast.imageRaySc.controlTheRay = true;
    }

    
}
