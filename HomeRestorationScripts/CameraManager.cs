using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public CinemachineVirtualCamera cam1;
    public CinemachineVirtualCamera cam2;
    public CinemachineVirtualCamera cam3;
    public static CameraManager cameraManagerScript;
    private void Start()
    {
        cameraManagerScript = GetComponent<CameraManager>();
    }


    public void SetCamera1On()
    {
        cam1.gameObject.SetActive(true);
        cam2.gameObject.SetActive(false);

    }
    public void SetCamera2On()
    {
        cam1.gameObject.SetActive(false);
        cam2.gameObject.SetActive(true);
    }

    public void SetCamera3On()
    {
        cam2.gameObject.SetActive(false);
        cam3.gameObject.SetActive(true);
    }

}
