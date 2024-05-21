using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameModeSelector1 : MonoBehaviour
{
    public TMP_Dropdown gameModeDropdown1;
    public int gamemode1_1;

    void Start()
    {
        gameModeDropdown1.onValueChanged.AddListener(delegate { Dropdown1_1(); });
        if (PlayerPrefs.HasKey("dropdownvalueone"))
        {
            LoadController();
        }
        else
        {
            Dropdown1_1();
        }
    }
    void Update()
    {
        LoadController();
    }

    public void Dropdown1_1()
    {
        if(gameModeDropdown1.value == 0) //Opção Keyboard escolhida
        {
            gamemode1_1 = 1;
            PlayerPrefs.SetInt("controller",gamemode1_1);
        }
        else if(gameModeDropdown1.value == 1) //Opção Joystick escolhida
        {
            gamemode1_1 = 2;
            PlayerPrefs.SetInt("controller",gamemode1_1);
        }
        PlayerPrefs.SetInt("dropdownvalueone", gameModeDropdown1.value);
    }
    private void LoadController()
    {
        gameModeDropdown1.value = PlayerPrefs.GetInt("dropdownvalueone");
        Dropdown1_1();
    }
}
