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
    private float moveTimer = 0f; //Tempo para mudar de estado
    private float stopTimer = 0f; //Mudança de estado
    private bool isMovingRight = true; //Flag para indicar direção de movimento
    private int d = 1;  //Ajustar animação
    private Animator anime;
    public PlayerHurt_Death1 deathcontroller1;
    public PlayerHurt_Death2 deathcontroller2;
    public PlayerBlock1 blockcontroller1;
    public PlayerBlock2 blockcontroller2;

    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        if(ehealth > 0)
        {
            Move();
            Attack();
        }
        if(ehealth <= 0) Death();
    }

    void Move()
    {
        if(stopTimer > 0)
        {
            stopTimer -= Time.deltaTime;
            anime.SetBool("walk", false);
            return;
        }
        if(moveTimer <= 0)
        {
            if(isMovingRight) isMovingRight = false;
            else isMovingRight = true;
            moveTimer = Random.Range(1f, 3f);   //Inicia o timer de movimento com tempo de espera aleatório entre 1s e 3s
            stopTimer = Random.Range(2f, 4f);   //Inicia o timer do tempo de espera aleatório entre 3s e 6s
        }
        if(isMovingRight)
        {
            anime.SetBool("walk", true);
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if(!isMovingRight)
        {
            anime.SetBool("walk", true);
            transform.Translate(Vector2.left * (-speed) * Time.deltaTime);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        moveTimer -= Time.deltaTime;
    }

    public void TakeDamage(int pdamage)
    {
        ehealth -= pdamage;   //Vida do inimigo perde o valor do dano do player
        anime.SetTrigger("hurt");
    }

    void Attack()
    {
        timesinceAttack += Time.deltaTime;  //Conta o tempo
        if(timesinceAttack > 0.8f) //É possível atacar após 0.8s do último ataque
        {
            EnemyAttacking = true;
            Collider2D[] playersToDamage = Physics2D.OverlapCircleAll(attackpos.position, attackrange, alvos);   //Nº de players no "círculo"
            if(playersToDamage.Length > 0)
            {
                foreach (Collider2D player in playersToDamage)
                {
                    //Verifica se o jogador é Player1 ou Player2 e aplica o dano de acordo
                    if (player.CompareTag("Player1") && !deathcontroller1.isDead)
                    {
                        anime.SetTrigger("attack"); //"Dispara" o parâmetro attack
                        if (!blockcontroller1.isBlock) player.GetComponent<PlayerHurt_Death1>().TakeDamage(edamage);
                    }
                    else if (player.CompareTag("Player2") && !deathcontroller2.isDead)
                    {
                        anime.SetTrigger("attack"); //"Dispara" o parâmetro attack
                        if (!blockcontroller2.isBlock) player.GetComponent<PlayerHurt_Death2>().TakeDamage(edamage);
                    }
                }
            }
            timesinceAttack = 0.0f;   //Recomeça a contar o tempo
        }
        EnemyAttacking = false;
    }

    public void Death()
    {
        if(d == 1) 
        {
            anime.SetTrigger("death");
            GameController.instance.totalScore += 270;
            GameController.instance.UpdateScoreText();
        }
        d++;
        Destroy(gameObject, 0.7f); //Desaparecimento do inimigo
    }
}