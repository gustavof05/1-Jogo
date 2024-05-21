using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
    
public class pauseMenu : MonoBehaviour
{
    public GameObject Pause; 
    public static bool ispaused = false;
    public GameObject Controllersmenu;
    public GameObject Audiomenu;
    public Animator DescerAMenu;
    public Animator DescerCMenu;
    public Animator transition;
    public float transitiontime = 1f;
    private bool isAudioMenuActive = false;
    private bool isControllersMenuActive = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Pause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Pause Joystick 1") || Input.GetButtonDown("Pause Joystick 2"))  /*&& !isAudioMenuActive && !isControllersMenuActive*/)
        {
            if(ispaused)
            {
                resumeGame();
            }
            else
            {
                pauseGame();
            }
        }
    }
    public void pauseGame()
    {       
        Pause.SetActive(true);
        Time.timeScale = 0f;
        ispaused = true;

    }
    public void resumeGame()
    {
        Pause.SetActive(false);
        Time.timeScale = 1f;
        ispaused = false;
    }
    public void AudioMenu()
    {
        Pause.SetActive(false);
        Audiomenu.SetActive(true);
        DescerAMenu.SetFloat("DescerAMenu", 1);
    }  

    public void backfromcontrollers()
    {
        Controllersmenu.SetActive(false);
        Pause.SetActive(true);
        isControllersMenuActive = true;
    }
      public void backfromaudio()
    {
        Audiomenu.SetActive(false);
        Pause.SetActive(true);
        isControllersMenuActive=true;
    }

    public void ControllersMenu()
    {
        Pause.SetActive(false);
        Controllersmenu.SetActive(true);
        DescerCMenu.SetFloat("DescerCMenu", 1);
    }
    public void GameQuit()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
    public void LoadLevel(string SceneName)
    {
        Pause.SetActive(false);
        StartCoroutine(Load(SceneName));
    }    

    IEnumerator Load(string SceneName)
    {
        Time.timeScale = 1f;
        transition.SetTrigger("start");
        yield return new WaitForSeconds(transitiontime);
        SceneManager.LoadScene(SceneName);
    }
}
