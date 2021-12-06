using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public int NumberOfPills = 10;
    public GameObject RespawnPoint;

    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().PlayPickUpSound();
            collision.gameObject.GetComponent<ShootingController>().AddPills(NumberOfPills);
            collision.gameObject.transform.Find("DialogBox").GetComponent<DialogBoxController>().ShowAddedAmmo();
            if (RespawnPoint != null)
            {
                RespawnPoint.GetComponent<ItemRespawnPointController>().PlaceNewItem();
            }
            Destroy(this.gameObject);
        }

    }
}
