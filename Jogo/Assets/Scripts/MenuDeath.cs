using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDeath : MonoBehaviour
{
    public PlayerHurt_Death1 controlador1;
    public PlayerHurt_Death2 controlador2;
    public GameObject menu;

    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(controlador1.isDead && controlador2.isDead){menu.SetActive(true);}
    }
}
