using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCRespawnPointController : MonoBehaviour
{
    public List<GameObject> NPCs;
    public int RespawnTime = 1000;
    private int _respawnTime;
    public NPCController.NPCOrientation Orientation;

    public bool IsActive;

    // Start is called before the first frame update
    void Start()
    {
        IsActive = false;
        _respawnTime = RespawnTime;
        //Respawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsActive)
        {
            RespawnTime--;
            if (RespawnTime <= 0)
            {
                RespawnTime = _respawnTime;
                Respawn();
            } 
        }
    }

    public void Activate()
    {
        IsActive = true;
    }

    public void Deactivate()
    {
        IsActive = false;
    }

    private void Respawn()
    {
        GameObject singleShot = Instantiate(NPCs[Random.Range(0, NPCs.Count - 1)], this.gameObject.transform.position, Quaternion.identity);
        singleShot.GetComponent<NPCController>().Orientation = Orientation;
    }
}
