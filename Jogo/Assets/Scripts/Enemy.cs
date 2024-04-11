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
    private int d = 1;  //Ajustar animação
    private Animator anime;

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
        if(ehealth <= 0) Death();
    }

    void Move()
    {
        //transform.Translate(Vector2.left * speed * Time.deltaTime);
        //Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        //transform.position += movement * Time.deltaTime * Speed;
        if(Input.GetAxis("Horizontal") > 0f)
        {
            anime.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);    //Mexer no eixo posicional do player
        }
        else if(Input.GetAxis("Horizontal") < 0f)
        {
            anime.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);  //Mexer no eixo posicional do player
        }
        else anime.SetBool("walk", false);
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
            Collider2D[] playersToDamage = Physics2D.OverlapCircleAll(attackpos.position, attackrange, alvos);   //Nº de inimigos (cada entidade) no "círculo"
            /*for(int i = 0; playersToDamage.Length; i++)
            {
                playersToDamage[i].GetComponent<Player 1>().TakeDamage(edamage);
            }*/
            timesinceAttack = 0.0f;   //Recomeça a contar o tempo
        }
        EnemyAttacking = false;
    }

    public void Death()
    {
        if(d == 1) anime.SetTrigger("death");
        d++;
        Destroy(gameObject, 0.7f); //Desaparecimento do inimigo
    }
}
