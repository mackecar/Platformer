using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int target = 60;

    public GameObject Player;

    void Awake()
    {
        if (Player != null)
        {
            Player.GetComponent<PlayerController>().CanMove = false;
        }

        StartCoroutine(SceneStart());

        Application.targetFrameRate = target;
    }

    void Update()
    {
        if (Application.targetFrameRate != target)
        {
            Application.targetFrameRate = target;
        }
    }

    private IEnumerator SceneStart()
    {
        yield return new WaitForSeconds(2f);
        if (Player != null)
        {
            Player.GetComponent<PlayerController>().CanMove = true;
        }
    }
}
