using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelRespawnPointController : MonoBehaviour
{
    public GameObject Barrel;
    public int Direction = -1; 
    public int Speed = 1; 

    // Start is called before the first frame update
    void Start()
    {
        
        Respawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn()
    {
        GameObject singleShot = Instantiate(Barrel, this.gameObject.transform.position, Quaternion.identity);
        singleShot.GetComponent<BarrelMoving>().Direction = Direction;
        singleShot.GetComponent<BarrelMoving>().Speed = Speed;
    }
}
