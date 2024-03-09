using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuButtons : MonoBehaviour
{
    public void StartScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void GameQuit()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }

}
