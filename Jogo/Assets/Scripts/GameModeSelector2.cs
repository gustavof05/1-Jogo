using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameModeSelector2 : MonoBehaviour
{
    public TMP_Dropdown gameModeDropdown2;
    public int gamemode2_1 = 1;

    void Start()
    {
        gameModeDropdown2.onValueChanged.AddListener(delegate { Dropdown2_1(); });
    }

    public void Dropdown2_1()
    {
        if(gameModeDropdown2.value == 0)
        {
            gamemode2_1 = 1;
        }
        else if(gameModeDropdown2.value == 1)
        {
            gamemode2_1 = 2;
        }
    }
}
