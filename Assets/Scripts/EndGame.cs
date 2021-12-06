using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public GameObject FadeOutBackGround;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(ChangeScene());
        }
    }

    private IEnumerator ChangeScene()
    {
        FadeOutBackGround.GetComponent<Animator>().SetBool("IsEndGame", true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("EndGame");
    }
}
