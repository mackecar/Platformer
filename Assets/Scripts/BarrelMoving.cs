using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelMoving : MonoBehaviour
{
    public int Direction = 1;
    public float Speed = 1f;

    private bool _canMove = false;
    private Rigidbody2D _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_canMove)
        {
            transform.Rotate(Vector3.forward * Speed*Direction);
            _rigidbody.velocity = new Vector2(0.3f*Speed * Direction, _rigidbody.velocity.y);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platform" || other.gameObject.tag == "Ground")
        {
            _canMove = true;
        }

    }
}
