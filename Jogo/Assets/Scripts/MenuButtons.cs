using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuButtons : MonoBehaviour
{
    public GameObject MainMenuButtons;
    public GameObject Levels;
    public GameObject Options;
    public GameObject Audiomenu;
    public GameObject Controllersmenu;

    public Animator DescerLMenu;
    public Animator DescerMMenu;
    public Animator DescerOMenu;
    public Animator DescerAMenu;
    public Animator DescerCMenu;


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

    public void OptionsMenu()
    {
        MainMenuButtons.SetActive(false);
        Options.SetActive(true);
        DescerOMenu.SetFloat("DescerOMenu", 1);
    }

    public void AudioMenu()
    {
        Options.SetActive(false);
        Audiomenu.SetActive(true);
        DescerAMenu.SetFloat("DescerAMenu", 1);
    }  

    public void BackToOptions()
    {
        Audiomenu.SetActive(false);
        Options.SetActive(true);
        DescerOMenu.SetFloat("DescerOMenu", 1);
    }

    public void ControllersMenu()
    {
        Options.SetActive(false);
        Controllersmenu.SetActive(true);
        DescerCMenu.SetFloat("DescerCMenu", 1);
    }

    public void BackToOptions2()
    {
        Controllersmenu.SetActive(false);
        Options.SetActive(true);
        DescerOMenu.SetFloat("DescerOMenu", 1);
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

    public void CancelOptions()
    {
        Options.SetActive(false);
        MainMenuButtons.SetActive(true);
        DescerMMenu.SetFloat("DescerMMenu",1);
    }
}


