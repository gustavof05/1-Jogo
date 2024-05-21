using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameModeSelector2 : MonoBehaviour
{
    public TMP_Dropdown gameModeDropdown2;
    public int gamemode2_1;

    public GameObject player2;

    void Start()
    {

        gameModeDropdown2.onValueChanged.AddListener(delegate { Dropdown2_1(); });
        if (PlayerPrefs.HasKey("dropdownvalue"))
        {
            LoadController();
        }
        else
        {
            Dropdown2_1();
        }
    }

    public void Dropdown2_1()
    {
        if(gameModeDropdown2.value == 0)
        {
            player2.SetActive(true);
            gamemode2_1 = 1;
            PlayerPrefs.SetInt("controller2",gamemode2_1);
        }
        else if(gameModeDropdown2.value == 1)
        {
            player2.SetActive(true);
            gamemode2_1 = 2;
            PlayerPrefs.SetInt("controller2",gamemode2_1);
        }
        else if(gameModeDropdown2.value == 2)
        {
            player2.SetActive(false);
        }
        PlayerPrefs.SetInt("dropdownvalue", gameModeDropdown2.value);
    }
    private void LoadController()
    {
        gameModeDropdown2.value = PlayerPrefs.GetInt("dropdownvalue");
        Dropdown2_1();
    }
}
