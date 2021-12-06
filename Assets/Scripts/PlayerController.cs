using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public bool CanMove = true;

    public Animator Animator;

    public float Speed = 0.01f;
    public float JumpForce = 1f;

    public HorizontalOrientation Orientation = HorizontalOrientation.Right;


    private float _defaultSpeed;
    private float _runningSpeed;
    private float _jumpForce;
    private float _runningJumpForce;
    
    private Rigidbody2D _playerRigidbody2D;
    private float _directionX;

    private bool _canJump;
    private BoxCollider2D _playerBoxCollider2D;

    public AudioClip PickUp;
    private AudioSource _audio; 

    // Start is called before the first frame update
    void Start()
    {
        _playerRigidbody2D = GetComponent<Rigidbody2D>();
        _defaultSpeed = Speed;
        _runningSpeed = Speed *2;
        _jumpForce = JumpForce;
        _runningJumpForce = JumpForce * 1.1f;
        _playerBoxCollider2D = GetComponent<BoxCollider2D>();
        _audio = GetComponent<AudioSource>();
    }

    public void PlayPickUpSound()
    {
        _audio.clip = PickUp;
        _audio.Play();
    }

    // Update is called once per frame
    void Update()
    {

        if (CanMove)
        {
            //Jump
            if (Input.GetKeyDown(KeyCode.Space) && _canJump)
            {
                _canJump = false;
                _playerRigidbody2D.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            }

            //Run
            if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && Input.GetAxis("Horizontal") != 0)
            {
                JumpForce = _runningJumpForce;
                Speed = _runningSpeed;
                Animator.SetBool("IsRunning", true);
            }
            else
            {
                JumpForce = _jumpForce;
                Speed = _defaultSpeed;
                Animator.SetBool("IsRunning", false);
            }

            //Crouch
            if (Input.GetKeyDown(KeyCode.C))
            {
                Animator.SetBool("IsCrouching", true);
                CrouchBoxResize(true);
            }
            if (Input.GetKeyUp(KeyCode.C))
            {
                Animator.SetBool("IsCrouching", false);
                CrouchBoxResize(false);
            }

            _directionX = Input.GetAxis("Horizontal") * Speed;

            //Walking orientation
            if (Input.GetAxis("Horizontal") > 0)
            {
                Orientation = HorizontalOrientation.Right;
            }

            if (Input.GetAxis("Horizontal") < 0)
            {
                Orientation = HorizontalOrientation.Left;
            }


            Animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
            Animator.SetBool("IsJumping", !_canJump); 
        }
    }

    void FixedUpdate()
    {
        if (CanMove)
        {
            //Moving
            _playerRigidbody2D.velocity = new Vector2(_directionX, _playerRigidbody2D.velocity.y);
            SetSpriteOrientation(); 
        }
    }

    void SetSpriteOrientation()
    {
        if (Orientation == HorizontalOrientation.Right)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if (Orientation == HorizontalOrientation.Left)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _canJump = true;
        }

        if (collision.gameObject.tag == "Platform")
        {
            _canJump = true;
            gameObject.transform.parent = collision.gameObject.transform;
        }

        if (collision.gameObject.tag == "Lava")
        {
            collision.gameObject.GetComponent<Collider2D>().enabled = false;
            _canJump = true;
            CanMove = false;
            GetComponent<PlayerLife>().IsKilled = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platform")
        {
            _canJump = false;
            gameObject.transform.parent = null;
        }
        
    }

    void CrouchBoxResize(bool isCrouching)
    {
        if (isCrouching)
        {
            _playerBoxCollider2D.size = new Vector2(_playerBoxCollider2D.size.x, _playerBoxCollider2D.size.y/2);
            _playerBoxCollider2D.offset = new Vector3(0, -0.07f);
        }
        else
        {
            _playerBoxCollider2D.size = new Vector2(_playerBoxCollider2D.size.x, _playerBoxCollider2D.size.x*2);
            _playerBoxCollider2D.offset = new Vector3(0, 0f);
        }
    }

    public enum HorizontalOrientation
    {
        Left,
        Right
    }

    
    
}
