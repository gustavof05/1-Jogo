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
    private float moveTimer = 0f; // Tempo para mover
    private bool isMovingRight = true; // Flag para indicar direção de movimento
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
        if(moveTimer <= 0)
        {
            if(isMovingRight) isMovingRight = false; //Inverte a direção de movimento
            else isMovingRight = true; //Inverte a direção de movimento
            moveTimer = Random.Range(1f, 3f);   //Inicia o timer de movimento com tempo de espera aleatório entre 1s e 3s
        }
        if(isMovingRight)
        {
            anime.SetBool("walk", true);
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else
        {
            anime.SetBool("walk", true);
            transform.Translate(Vector2.left * (-speed) * Time.deltaTime);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        //anime.SetBool("walk", false);
        moveTimer -= Time.deltaTime;
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
        timesinceAttack += Time.deltaTime;  //Conta o tempo
        if(timesinceAttack > 0.55f) //É possível atacar após 0.55s do último ataque
        {
            EnemyAttacking = true;
            Collider2D[] playersToDamage = Physics2D.OverlapCircleAll(attackpos.position, attackrange, alvos);   //Nº de players no "círculo"
            if(playersToDamage.Length > 0)
            {
                foreach (Collider2D player in playersToDamage)  //Causa dano aos jogadores dentro do alcance
                {
                    anime.SetTrigger("attack"); //"Dispara" o parâmetro attack
                    player.GetComponent<PlayerHurt_Death>().TakeDamage(edamage);
                }
            }
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
