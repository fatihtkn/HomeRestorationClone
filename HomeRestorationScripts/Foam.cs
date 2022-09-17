using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foam : MonoBehaviour,IOnPainted
{
    [SerializeField] private LayerMask mask;
    private IRayProvider rayProvider;
    public Vector3 gunOffset;
    public Collider mouseTarget;
    float count;
    private void Awake()
    {
        rayProvider = new MouseScreenRayProvider();
    }
    private void Update()
    {
        Siliconing();

    }
    public void Siliconing()
    {
        if (GameManager.state == GameManager.GameStates.Siliconing)
        {
            
                
            if (Physics.Raycast(rayProvider.CreateRay(), out RaycastHit hit, mask))
            {

                ToolManager.Instance.silicon_gun.transform.position = hit.point+gunOffset;
                if (hit.collider.CompareTag("Silicon"))
                {
                    hit.collider.gameObject.GetComponent<MeshRenderer>().enabled = true;
                    hit.collider.enabled = false;
                    count++;
                }
                
               

            }

            
            if (count >= 94)
            {
                OnPainted();

            }
            ProgressBar.progressbarSc.SetBar(count/100);

            


        }




    }

   

    public void OnPainted()
    {
        ConfettiManager.Instance.CreateConfetti();
        ButtonFunctionsManager.Instance.SetToPlasterButton.SetActive(true);
        ToolManager.Instance.SetGunActive(false);
        mouseTarget.enabled = false;
    }
}
