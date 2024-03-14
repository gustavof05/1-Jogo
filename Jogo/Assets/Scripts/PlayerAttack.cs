using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeforAttack;    //Cooldown de cada ataque
    public float starttimeforAttack;
    public Transform attackpos; //Posição de "ataque"
    public float attackrange;   //Range de ataque
    public int damage;    //Dano tirado por ataque
    public LayerMask inimigos;  //Camada onde estão os inimigos (para só "acertar" neles)
    public Animator anim;
    
    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if(timeforAttack <= 0)  //É possível atacar (cooldown=0)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackpos.position, attackrange, inimigos);   //Nº de inimigos (cada entidade) no "círculo"
                for(int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                } 
            }
            timeforAttack = starttimeforAttack; //Recomeça a contar o cooldown
        }
        else
        {
            timeforAttack -= Time.deltaTime;
        }
    }

    /*void void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackpos.position, attackrange);
    }*/
}
