using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlock2 : MonoBehaviour
{
    public bool isBlock = false;
    private Animator blanim;
    public PlayerHurt_Death deathcontroller;
    [SerializeField] GameModeSelector2 gamemode2_2;

    // Start is called before the first frame update
    void Start()
    {
        blanim = GetComponent<Animator>();
        gamemode2_2.gamemode2_1 = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(!deathcontroller.isDead) Block();    //Se não estiver morto
    }

    void Block()
    {
        if(gamemode2_2.gamemode2_1 == 1)
        {
            if(Input.GetKeyDown(KeyCode.LeftControl)) //Enquanto o botão for premido
            {
                isBlock = true;
                blanim.SetTrigger("block");
                blanim.SetBool("isBlocking", true); //Está a defender
            }
            else if(Input.GetKeyUp(KeyCode.LeftControl))
            {
                blanim.SetBool("isBlocking", false);
                isBlock = false; 
            }
        }
        else if(gamemode2_2.gamemode2_1 == 2)
        {
            if(Input.GetButtonDown("Block Joystick 2")) //Enquanto o botão for premido
            {
                isBlock = true;
                blanim.SetTrigger("block");
                blanim.SetBool("isBlocking", true); //Está a defender
            }
            else if (Input.GetButtonUp("Block Joystick 2"))
            {
                blanim.SetBool("isBlocking", false);
                isBlock = false;    
            }
        }
    }
}
