using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMopHead : MonoBehaviour
{
    private Rigidbody rb;
    
    
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        


    }
    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            rb.AddTorque(Vector3.up, ForceMode.Acceleration);
        }
        
    }
   
}
