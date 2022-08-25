using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foam : MonoBehaviour
{
    [SerializeField] private LayerMask mask;
    [SerializeField] private Texture2D transparentTex;
    public Vector3 gunOffset;
    private Vector3 swipeDelta, startTouch;
    public Collider mouseTarget;
    float count;
    
       
        


    private void Start()
    {
        count = 0;
    }
    private void Update()
    {
        Siliconing();

    }
    public void Siliconing()
    {
        if (GameManager.state == GameManager.GameStates.Siliconing)
        {
           

            
            
            if (Input.GetMouseButtonDown(0))
            {
                startTouch = Input.mousePosition;
            }
            else if (Input.GetMouseButton(0))
            {
                swipeDelta = Input.mousePosition - startTouch;
                startTouch = Input.mousePosition;
                
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, mask)!=false /*& swipeDelta.sqrMagnitude > 1*/)
                {

                    ToolManager.toolmanagerSc.silicon_gun.transform.position = hit.point+gunOffset;
                    if (hit.collider.CompareTag("Silicon"))
                    {
                        hit.collider.gameObject.GetComponent<MeshRenderer>().enabled = true;
                        hit.collider.enabled = false;
                        count++;
                    }
                    
                    //GameObject obj = Instantiate(sphere, hit.point, Quaternion.identity);
                    //obj.transform.SetParent(parent);

                }

            }
            if (Input.GetMouseButtonUp(0))
            {
                swipeDelta = Vector3.zero;
                startTouch = Vector3.zero;
                


            }
            if (count >= 94)
            {

                ConfettiManager.confettiSc.CreateConfetti();
                ButtonFunctionsController.buttonManager.setToPlasterButton.SetActive(true);
                ToolManager.toolmanagerSc.SetGunActive(false);
                mouseTarget.enabled = false;
                count = 0;

            }
            ProgressBar.progressbarSc.SetBar(count/100);

            


        }




    }

    private IEnumerator CoolDown()
    {
        

        yield return new WaitForSeconds(2f);
        


    }


}
