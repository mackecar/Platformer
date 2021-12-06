using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public void LoadSceneById(int id)
    {
        SceneManager.LoadScene(id);
    }

    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator LoadLevel(string levelName)
    {

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelName);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        GameIsPaused = true;
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        GameIsPaused = false;
        Time.timeScale = 1f;
    }
}
