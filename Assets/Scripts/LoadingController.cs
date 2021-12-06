using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingController : MonoBehaviour
{
    public bool IsLevelEasy = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeScene());
    }

    private IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(1f);
        GetComponent<MenuController>().LoadSceneByName(IsLevelEasy ? "Level - easy" : "Level");
    }

}
