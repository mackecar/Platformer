using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRespawnPointController : MonoBehaviour
{
    public GameObject Item;
    [Range(1,10)]
    public float RespawnTime = 2;

    // Start is called before the first frame update
    void Start()
    {
        Item.GetComponent<ItemController>().RespawnPoint = this.gameObject;
        StartCoroutine(Respawn());
    }


    public void PlaceNewItem()
    {
        StartCoroutine(Respawn());
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(RespawnTime);
        GameObject item = Instantiate(Item, this.gameObject.transform.position, Quaternion.identity);
    }
}
