using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurt_Death : MonoBehaviour
{
    private Animator hdanim;
    public bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        hdanim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isDead) 
        {
            Hurt();
            Death();
        }
    }

    void Hurt()
    {
        if (Input.GetKeyDown("q")) hdanim.SetTrigger("hurt");
    }

    void Death()
    {
        if (Input.GetKeyDown("e"))
        {
            hdanim.SetTrigger("death");
            isDead = true;  //Está morto
        }
    }        
}
