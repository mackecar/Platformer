using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTriggerRespawnController : MonoBehaviour
{
    public bool IsEnter =  true;
    public GameObject RespawnPoint;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (IsEnter)
            {
                RespawnPoint.gameObject.GetComponent<NPCRespawnPointController>().Activate(); 
            }
            else
            {
                RespawnPoint.gameObject.GetComponent<NPCRespawnPointController>().Deactivate();
            }
        }
    }
}
