using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public GameObject MainCamera;
    public int ActivateCamera = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            MainCamera.GetComponent<CameraController>().SetCamera(ActivateCamera);
        }
    }
}
