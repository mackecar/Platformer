using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappearing : MonoBehaviour
{
    public int FrameInterval = 100;
    public float TimeIntervalDelay = 1.5f;
    private bool _canStart = false;
    private bool _isShowed = true;
    private int _frameCount = 0;

    void Start()
    {
        StartCoroutine(DelayStart());
    }

    // Update is called once per frame
    void Update()
    {
        if (_canStart)
        {
            _frameCount++;
            if (_frameCount > FrameInterval)
            {
                ShowHide();
                _frameCount = 0;
            } 
        }
    }

    private  void ShowHide()
    {
        _isShowed = !_isShowed;

        if (_isShowed)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private IEnumerator DelayStart()
    {
        yield return new WaitForSeconds(TimeIntervalDelay);
        _canStart = true;
    }
}
