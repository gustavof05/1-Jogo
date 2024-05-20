using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class pauseMenu : MonoBehaviour
{
    public GameObject Pause; 
    public static bool ispaused = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Pause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Pause Joystick 1") || Input.GetButtonDown("Pause Joystick 2"))
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
}
