using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlock : MonoBehaviour
{
    public bool isBlock = false;
    private Animator blanim;
    public PlayerHurt_Death deathcontroller;

    // Start is called before the first frame update
    void Start()
    {
        blanim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!deathcontroller.isDead) Block();    //Se não estiver morto
    }

    void Block()
    {
        if(Input.GetMouseButtonDown(1)) //Enquanto o botão for premido
        {
            isBlock = true;
            blanim.SetTrigger("block");
            blanim.SetBool("isBlocking", true); //Está a defender
        }
        else if (Input.GetMouseButtonUp(1))
        {
            blanim.SetBool("isBlocking", false);
            isBlock = false;    
        }
    }
}
