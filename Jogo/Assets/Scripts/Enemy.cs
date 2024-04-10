using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int ehealth; //Vida do inimigo
    public float speed; //Velocidade do inimigo
    public int edamage;    //Dano tirado por ataque
    public Transform attackpos; //Posição de "ataque"
    public float attackrange;   //Range de ataque
    public LayerMask alvos;  //Camada onde estão os inimigos (para só "acertar" neles)
    public bool EnemyAttacking = false;
    private float timesinceAttack = 0.55f;   //Tempo desde o último ataque (inicial)
    private float c = 0f;
    private Animator anime;
    public PlayerAttack p;

    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Attack();
        Death();
    }

    void Move()
    {
        //anime.SetBool("walk", true);
        //transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public void TakeDamage(int pdamage)
    {
        //Instantiate(transform.position, Quaternion.identity);
            ehealth -= pdamage;   //Vida do inimigo perde o valor do dano do player
            anime.SetTrigger("hurt");
            Debug.Log("damage taken from player");
    }

    void Attack()
    {
        if(timesinceAttack > 0.55f) //É possível atacar após 0.55s do último ataque
        {
            EnemyAttacking = true;
            anime.SetTrigger("attack"); //"Dispara" o parâmetro attack
            /*Collider2D[] playersToDamage = Physics2D.OverlapCircleAll(attackpos.position, attackrange, alvos);   //Nº de inimigos (cada entidade) no "círculo"
            for(int i = 0; playersToDamage.Length; i++)
            {
                playersToDamage[i].GetComponent<Player 1>().TakeDamage(edamage);
            }*/
            timesinceAttack = 0.0f;   //Recomeça a contar o tempo
        }
        EnemyAttacking = false;
    }

    public void Death()
    {
        if(ehealth <= 0)
        {
            anime.SetTrigger("death");
            /*for(c =0f; c <= 0.35f; c += Time.deltaTime) 
            {
                Destroy(gameObject);   //Desaparecimento do inimigo
                c = 0f;
            }*/
        }
    }
}
