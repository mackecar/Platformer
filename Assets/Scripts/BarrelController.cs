using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class BarrelController : MonoBehaviour
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
                    //GetComponent<SpriteRenderer>().enabled = false;
                    //GetComponent<CircleCollider2D>().enabled = false;
                    //Destroy(this.gameObject, 0.5f);
                }

                
            }

        }
    }
}
