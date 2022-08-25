using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ImageRaycast : MonoBehaviour
{
    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    public EventSystem m_EventSystem;
    public bool controlTheRay;
    public static ImageRaycast imageRaySc;


    private void Start()
    {
        controlTheRay = false;
        m_Raycaster = GetComponent<GraphicRaycaster>();
        m_EventSystem = GetComponent<EventSystem>();
        imageRaySc = GetComponent<ImageRaycast>();
    }

    private void Update()
    {
        
        if (Input.GetMouseButtonUp(0)&controlTheRay)
        {
            //Set up the new Pointer Event
            m_PointerEventData = new PointerEventData(m_EventSystem);
            //Set the Pointer Event Position to that of the mouse position
            m_PointerEventData.position = Input.mousePosition;

            //Create a list of Raycast Results
            List<RaycastResult> results = new List<RaycastResult>();

            //Raycast using the Graphics Raycaster and mouse click position
            m_Raycaster.Raycast(m_PointerEventData, results);
            
            if(GameManager.state == GameManager.GameStates.SelectingRoomTemplate)
            {
                ISelectRoom Interractable = results[0].gameObject.GetComponent<ISelectRoom>();
                if (Interractable != null)
                {
                    Interractable.Interact();

                }
            }


            if( GameManager.state == GameManager.GameStates.SelectingColor)
            {
                ISelectColor selectColor = results[0].gameObject.GetComponent<ISelectColor>();
                if (selectColor != null)
                {
                    selectColor.SelectedColor();
                    GameManager.state = GameManager.GameStates.WallPainting;
                    

                }
            }
           
           
        }
    }

}
