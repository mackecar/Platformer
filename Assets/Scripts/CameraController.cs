using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Camera1;
    public GameObject Camera2;
    public GameObject Camera3;

    void Start()
    {
        Camera1.GetComponent<CinemachineVirtualCamera>().Priority = 10;
        Camera2.GetComponent<CinemachineVirtualCamera>().Priority = 2;
        Camera3.GetComponent<CinemachineVirtualCamera>().Priority = 1;
    }


    public void SetCamera(int cameraId)
    {
        switch (cameraId)
        {
            case 1:
                SetCamera1();
                break;
            case 2:
                SetCamera2();
                break;
            case 3:
                SetCamera3();
                break;
            default:
                SetCamera3();
                break;
        }
    }

    private void SetCamera1()
    {
        Camera1.GetComponent<CinemachineVirtualCamera>().Priority = Camera2.GetComponent<CinemachineVirtualCamera>().Priority + Camera3.GetComponent<CinemachineVirtualCamera>().Priority + 1;
    }

    private void SetCamera2()
    {
        Camera2.GetComponent<CinemachineVirtualCamera>().Priority = Camera1.GetComponent<CinemachineVirtualCamera>().Priority + Camera3.GetComponent<CinemachineVirtualCamera>().Priority + 1;
    }

    private void SetCamera3()
    {
        Camera3.GetComponent<CinemachineVirtualCamera>().Priority = Camera1.GetComponent<CinemachineVirtualCamera>().Priority + Camera2.GetComponent<CinemachineVirtualCamera>().Priority + 1;
    }
}
