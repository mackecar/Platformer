using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelDestroyer : MonoBehaviour
{
    public GameObject RespawnPoint;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Barrel")
        {
            Destroy(other.gameObject);
            RespawnPoint.GetComponent<BarrelRespawnPointController>().Respawn();
        }

    }
}
