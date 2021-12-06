using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class NPCShootingController : MonoBehaviour
{
    public GameObject RightShotEmitter;
    public GameObject LeftShotEmitter;

    public GameObject Shot;
    public int MinFireRate = 20;
    public int MaxFireRate = 100;
    public int FixFireRate = 50;
    public bool IsRandomFireRite = false;
    public float BulletForce = 100;

    private int _frameCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_frameCount > 0)
        {
            _frameCount--;
        }

        if (_frameCount <= 0)
        {
            Shoot();
            _frameCount = IsRandomFireRite ? Random.Range(MinFireRate,MaxFireRate) : FixFireRate;
        }
    }

    void Shoot()
    {
        Vector3 position = Vector3.forward;
        Quaternion rotation = Quaternion.identity;
        Vector2 bulletForce = Vector2.zero;

        NPCController.NPCOrientation orientation = GetComponent<NPCController>().Orientation;

        if (orientation == NPCController.NPCOrientation.Right)
        {
            position = RightShotEmitter.transform.position;
            rotation = RightShotEmitter.transform.rotation;
            bulletForce = transform.right * BulletForce;
        }

        if (orientation == NPCController.NPCOrientation.Left)
        {
            position = LeftShotEmitter.transform.position;
            rotation = LeftShotEmitter.transform.rotation;
            bulletForce = (transform.right * -1) * BulletForce;
        }

        GameObject singleShot = Instantiate(Shot, position, rotation);
        singleShot.name = Guid.NewGuid().ToString();
        singleShot.GetComponent<Rigidbody2D>().AddForce(bulletForce);

        Destroy(singleShot, 5f);
    }
}
