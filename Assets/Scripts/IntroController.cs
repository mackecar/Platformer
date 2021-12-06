using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour
{
    public float Duration = 4;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IntroTimer(Duration));
    }

    private IEnumerator IntroTimer(float duration)
    {
        yield return new WaitForSeconds(duration);
        SceneManager.LoadScene(1);
    }
}
