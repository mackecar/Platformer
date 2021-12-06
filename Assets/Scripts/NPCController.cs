using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public NPCOrientation Orientation;
    public float Speed = 2;

    private Rigidbody2D _npcRigidbody2D;
    private float _directionX;

    // Start is called before the first frame update
    void Start()
    {
        if (Orientation == NPCOrientation.Right)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

        _npcRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Orientation == NPCOrientation.Left)
        {
            _directionX = 0.1f * Speed *-1;
        }
        else
        {
            _directionX = 0.1f * Speed;
        }
        
        _npcRigidbody2D.velocity = new Vector2(_directionX, _npcRigidbody2D.velocity.y);
    }

    public enum NPCOrientation
    {
        Left,Right
    }
}
