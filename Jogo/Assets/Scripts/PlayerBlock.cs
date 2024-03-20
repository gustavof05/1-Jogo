using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlock : MonoBehaviour
{
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
        if(!deathcontroller.isDead)
        {
            Block();
        }
    }

    void Block()
    {
        if(Input.GetMouseButtonDown(1)) //Se o botão for premido e não estiver a defender
        {
            blanim.SetTrigger("block");
            blanim.SetBool("isBlocking", true); //Está a defender
            /*Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackpos.position, attackrange, inimigos);   //Nº de inimigos (cada entidade) no "círculo"
            for(int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
            }*/ 
        }
        else if (Input.GetMouseButtonUp(1)) blanim.SetBool("isBlocking", false);
    }
}
