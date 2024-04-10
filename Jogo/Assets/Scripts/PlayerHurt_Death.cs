using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurt_Death : MonoBehaviour
{
    private Animator hdanim;
    public bool isDead = false;
    public PlayerAttack p;
    public Enemy e;

    // Start is called before the first frame update
    void Start()
    {
        hdanim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isDead) Death();
    }

    public void TakeDamage(int edamage)
    {
        if(!isDead)
        {
            p.phealth -= edamage; //Vida do player perde o valor do dano do inimigo
            hdanim.SetTrigger("hurt");
            Debug.Log("damage taken from enemy");
        }
    }

    void Death()
    {
        if (p.phealth <= 0)
        {
            hdanim.SetTrigger("death");
            isDead = true;  //Está morto
        }
    }        
}
