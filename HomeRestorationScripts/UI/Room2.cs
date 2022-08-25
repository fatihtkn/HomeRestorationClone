using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2 : MonoBehaviour,ISelectRoom
{
    [SerializeField] private GameObject roomItems_2;

    public void Interact()
    {

        roomItems_2.SetActive(true);
        SelectRoomDesign.roomDesignsc.SetSprites();
        ImageRaycast.imageRaySc.controlTheRay = true;
    }
}
