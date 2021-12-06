using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeScene());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * Time.deltaTime;
    }

    private IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(45f);
        SceneManager.LoadScene("Menu");
    }
}
