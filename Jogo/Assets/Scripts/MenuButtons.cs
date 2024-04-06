using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuButtons : MonoBehaviour
{
    public GameObject MainMenuButtons;
    public GameObject Levels;
    void Start()
    {
        Levels.SetActive(false);
    }
    public void StartGame()
    {
        MainMenuButtons.SetActive(false);
        Levels.SetActive(true);
    }

    public void GameQuit()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }

}


