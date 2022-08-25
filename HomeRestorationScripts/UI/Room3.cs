using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room3 : MonoBehaviour,ISelectRoom
{
    [SerializeField] private GameObject roomItems_3;

    public void Interact()
    {

        roomItems_3.SetActive(true);
        SelectRoomDesign.roomDesignsc.SetSprites();
        ImageRaycast.imageRaySc.controlTheRay = true;
    }
   
}
