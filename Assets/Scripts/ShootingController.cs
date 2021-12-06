using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShootingController : MonoBehaviour
{
    public int PillsCount = 0;
    public TextMeshProUGUI PillsCounter;

    public ShootingOrientation Orientation;
    public GameObject ShotPrefab1;
    public GameObject ShotPrefab2;
    private GameObject _shotPrefab;

    public float BulletForce = 100;
    public GameObject RightShotEmitter;
    public GameObject LeftShotEmitter;
    public GameObject Player;
    public int FireRate = 20;
    public int ForcedFireRate = 5;
    private bool _canShot;
    private int _frameCount;

    void Start()
    {
        _canShot = true;
        _shotPrefab = ShotPrefab1;
        PillsCounter.text = PillsCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _shotPrefab = ShotPrefab1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _shotPrefab = ShotPrefab2;
        }

        if (Input.GetKey(KeyCode.P) && _canShot)
        {
            gameObject.GetComponent<PlayerController>().Animator.SetBool("IsShooting", true);
            if (PillsCount > 0)
            {
                Shoot();
                _canShot = false;
                _frameCount = FireRate;
            }
            else
            {
                gameObject.transform.Find("DialogBox").GetComponent<DialogBoxController>().ShowOutOfAmmo();
            }
        }
        else
        {
            gameObject.GetComponent<PlayerController>().Animator.SetBool("IsShooting", false);
        }


        if (Input.GetKeyUp(KeyCode.P))
        {
            _frameCount = ForcedFireRate;
        }

        if (_frameCount > 0)
        {
            _frameCount--;
        }

        if (_frameCount <=0)
        {
            _canShot = true;
            _frameCount = 0;
        }

        //if (Input.GetKey(KeyCode.W))
        //{
        //    Orientation = ShootingOrientation.Up;
        //}

        if (Input.GetKey(KeyCode.D))
        {
            Orientation = ShootingOrientation.Right;
        }

        if (Input.GetKey(KeyCode.A))
        {
            Orientation = ShootingOrientation.Left;
        }

        //if (Input.GetKey(KeyCode.S))
        //{
        //    Orientation = ShootingOrientation.Down;
        //}

        //if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        //{
        //    Orientation = ShootingOrientation.RightUp;
        //}

        //if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        //{
        //    Orientation = ShootingOrientation.LeftUp;
        //}

        //if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        //{
        //    Orientation = ShootingOrientation.RightDown;
        //}

        //if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        //{
        //    Orientation = ShootingOrientation.LeftDown;
        //}

        
    }

    public void AddPills(int numberOfPills)
    {
        PillsCount += numberOfPills;
        PillsCounter.text = PillsCount.ToString();
    }

    public void ShootPill()
    {
        PillsCount--;
        PillsCounter.text = PillsCount.ToString();
    }

    void Shoot()
    {
        ShootPill();

        Vector3 position = Vector3.forward;
        Quaternion rotation = Quaternion.identity;
        Vector2 bulletForce = Vector2.zero;
        
        PlayerController.HorizontalOrientation orientation = Player.GetComponent<PlayerController>().Orientation;

        if (Orientation == ShootingOrientation.Right)
        {
            position = RightShotEmitter.transform.position;
            rotation = RightShotEmitter.transform.rotation;
            bulletForce = transform.right * BulletForce;
            _shotPrefab.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
        }

        if (Orientation == ShootingOrientation.Left)
        {
            position = LeftShotEmitter.transform.position;
            rotation = LeftShotEmitter.transform.rotation;
            bulletForce = (transform.right *-1)* BulletForce;
            _shotPrefab.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
        }

        //if (Orientation == ShootingOrientation.Up)
        //{
        //    position = LeftShotEmitter.transform.position;
        //    rotation = LeftShotEmitter.transform.rotation;
        //    bulletForce = (transform.up) * BulletForce;
        //    _shotPrefab.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
        //}

        //if (Orientation == ShootingOrientation.Down)
        //{
        //    position = LeftShotEmitter.transform.position;
        //    rotation = LeftShotEmitter.transform.rotation;
        //    bulletForce = (transform.up * -1) * BulletForce;
        //    _shotPrefab.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
        //}

        GameObject singleShot = Instantiate(_shotPrefab, position, rotation);
        singleShot.name = Guid.NewGuid().ToString();
        singleShot.GetComponent<Rigidbody2D>().AddForce(bulletForce);

        Destroy(singleShot, 5f);
    }

    public enum ShootingOrientation
    {
        Left,
        Right,
        Up,
        Down,
        LeftUp,
        LeftDown,
        RightUp,
        RightDown
    }
}
