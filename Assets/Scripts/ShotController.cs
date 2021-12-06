using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    public AudioClip HitSound;
    private AudioSource Audio;

    // Start is called before the first frame update
    void Start()
    {
        Audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Audio.clip = HitSound;
        Audio.Play();

        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<PolygonCollider2D>().enabled = false;
        Destroy(this.gameObject,0.5f);
    }
}
