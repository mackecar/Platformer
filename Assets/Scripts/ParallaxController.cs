using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    private float _length;
    private float _startPosition;
    public GameObject MainCamera;
    public float ParallaxEffect;


    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.position.x;
        _length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = (MainCamera.transform.position.x * (1-ParallaxEffect));
        float distance = (MainCamera.transform.position.x * ParallaxEffect);

        transform.position = new Vector3(_startPosition + distance, transform.position.y,transform.position.z);

        if (temp > _startPosition + _length) _startPosition += _length;
        else if (temp < _startPosition - _length) _startPosition -= _length;
    }
}
