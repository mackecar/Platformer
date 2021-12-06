using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public float FadeTime = 1f;

    public bool IsHit = false;
    public bool IsKilled = false;
    private Material _material;

    // Start is called before the first frame update
    void Start()
    {
        _material = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsHit)
        {
            gameObject.transform.Find("DialogBox").GetComponent<DialogBoxController>().ShowKilledMessage("Шта је бре ово Драгане!");
            gameObject.layer = LayerMask.NameToLayer("Front");
            FadeTime -= Time.deltaTime;

            if (FadeTime <= 0f)
            {
                FadeTime = 0;
                IsHit = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                GetComponent<PlayerController>().CanMove = false;
            }

            _material.SetFloat("_Fade", FadeTime);
        }

        if (IsKilled)
        {
            gameObject.transform.Find("DialogBox").GetComponent<DialogBoxController>().ShowKilledMessage("Шта је бре ово Драгане!");
            //gameObject.layer = LayerMask.NameToLayer("Background");
            GetComponent<SpriteRenderer>().sortingLayerName = "Background";
            Physics2D.IgnoreLayerCollision(0, 14);
            
            FadeTime -= Time.deltaTime;

            if (FadeTime <= 0f)
            {
                FadeTime = 0;
                IsHit = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                GetComponent<PlayerController>().CanMove = false;
            }

            _material.SetFloat("_Fade", FadeTime);
        }
    }

    private IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
