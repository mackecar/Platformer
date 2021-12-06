using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTheDoor : MonoBehaviour
{
    public Sprite OpenDoor;
    public Sprite CloseDoor;
    public SpriteRenderer Door;

    public AudioClip DoorSound;
    private AudioSource _audio;

    private bool _isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        _audio = GetComponent<AudioSource>();
        Door.sprite = CloseDoor;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !_isOpen)
        {
            _audio.clip = DoorSound;
            _audio.Play();
            Door.sprite = OpenDoor;
            _isOpen = true;
        }
    }
}
