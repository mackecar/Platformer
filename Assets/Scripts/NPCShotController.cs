using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCShotController : MonoBehaviour
{
    public AudioClip HitSound;
    public AudioClip Dying;
    private AudioSource _audio;


    // Start is called before the first frame update
    void Start()
    {
        _audio = GetComponent<AudioSource>();
        if (MenuController.GameIsPaused)
        {
            _audio.pitch = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!MenuController.GameIsPaused)
        {
            _audio.clip = HitSound;
            _audio.Play();

            if (collision.gameObject.tag == "Player")
            {
                _audio.clip = Dying;
                _audio.Play();
                collision.gameObject.GetComponent<PlayerLife>().IsHit = true;
            }

            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<PolygonCollider2D>().enabled = false;
            Destroy(this.gameObject, 0.5f);
        }
        
    }
}
