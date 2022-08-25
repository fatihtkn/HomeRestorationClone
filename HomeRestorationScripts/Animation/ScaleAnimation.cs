using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleAnimation : MonoBehaviour
{
    Vector3 desiredScale;
    private void Awake()
    {
        transform.localScale /= 4;
        desiredScale = transform.localScale * 4;
        for (int i = 0; i < transform.childCount; i++)
        {
            GetComponentsInChildren<Rigidbody>()[i].useGravity = false;
        }
        StartCoroutine(Timer());
    }
    private void FixedUpdate()
    {
        transform.localScale = Vector3.Slerp(transform.localScale, desiredScale, Time.deltaTime*6);
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.8f);
        for (int i = 0; i < transform.childCount; i++)
        {
            GetComponentsInChildren<Rigidbody>()[i].useGravity = true;
        }

    }
}
