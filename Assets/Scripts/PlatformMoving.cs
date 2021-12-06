using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoving : MonoBehaviour
{
    public Transform Position1;
    public Transform Position2;
    public float Speed = 1;
    public Transform StartPosition;

    private Vector3 _nextPosition;

    // Start is called before the first frame update
    void Start()
    {
        _nextPosition = StartPosition.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == Position1.position)
        {
            _nextPosition = Position2.position;
        }

        if (transform.position == Position2.position)
        {
            _nextPosition = Position1.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, _nextPosition, Speed * Time.deltaTime);
    }
}
