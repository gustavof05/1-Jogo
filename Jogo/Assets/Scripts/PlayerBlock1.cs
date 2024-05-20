using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlock1 : MonoBehaviour
{
    public bool isBlock = false;
    private Animator blanim;
    public PlayerHurt_Death deathcontroller;
    [SerializeField] GameModeSelector1 gamemode1_2;

    // Start is called before the first frame update
    void Start()
    {
        blanim = GetComponent<Animator>();
        gamemode1_2.gamemode1_1 = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(!deathcontroller.isDead) Block();    //Se não estiver morto
    }

    void Block()
    {
        if(gamemode1_2.gamemode1_1 == 1)
        {
            if(Input.GetKeyDown(KeyCode.RightShift)) //Enquanto o botão for premido
            {
                isBlock = true;
                blanim.SetTrigger("block");
                blanim.SetBool("isBlocking", true); //Está a defender
            }
            else if(Input.GetKeyUp(KeyCode.RightShift))
            {
                blanim.SetBool("isBlocking", false);
                isBlock = false; 
            }
        }
        else if(gamemode1_2.gamemode1_1 == 2)
        {
            if(Input.GetButtonDown("Block Joystick 1")) //Enquanto o botão for premido
            {
                isBlock = true;
                blanim.SetTrigger("block");
                blanim.SetBool("isBlocking", true); //Está a defender
            }
            else if (Input.GetButtonUp("Block Joystick 1"))
            {
                blanim.SetBool("isBlocking", false);
                isBlock = false;    
            }
        }
    }
}
