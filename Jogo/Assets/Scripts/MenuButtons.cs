using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuButtons : MonoBehaviour
{
    public GameObject MainMenuButtons;
    public GameObject Levels;
    public Animator DescerLMenu;
    public Animator DescerMMenu;

    void Start()
    {
        DescerMMenu.SetFloat("DescerMMenu",1);
        Levels.SetActive(false);
    }
    public void StartGame()
    {
        MainMenuButtons.SetActive(false);
        Levels.SetActive(true);
        DescerLMenu.SetFloat("DescerLMenu", 1);
    }

    public void GameQuit()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }

    public void Cancel()
    {
        Levels.SetActive(false);
        MainMenuButtons.SetActive(true);
        DescerMMenu.SetFloat("DescerMMenu",1);
    }

}


