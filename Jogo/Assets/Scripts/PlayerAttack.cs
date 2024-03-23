using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timesinceAttack = 0.55f;   //Tempo desde o último ataque (inicial)
    public Transform attackpos; //Posição de "ataque"
    public float attackrange;   //Range de ataque
    public int damage;    //Dano tirado por ataque
    public LayerMask inimigos;  //Camada onde estão os inimigos (para só "acertar" neles)
    public Animator attanim;
    public bool isAttacking = false;
    private int attackIndex = 1;
    public static PlayerAttack instance;
    public PlayerHurt_Death deathcontroller;
    
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        attanim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timesinceAttack += Time.deltaTime;  //Conta o tempo
        if(!deathcontroller.isDead) //Se não estiver morto
        {
            Attack();
        }
    }

    void Attack()
    {
        if(Input.GetMouseButtonDown(0) && timesinceAttack > 0.55f) //É possível atacar após 0.55s do último ataque
        {
            if (attackIndex > 3) attackIndex = 1;   //Se tiver feito o 3ºataque, volta ao 1º
            if (timesinceAttack > 1.0f) attackIndex = 1;    //Se tiver passado 1s após o último ataque, volta ao 1º
            attanim.SetTrigger("attack" + attackIndex); //"Dispara" o parâmetro attackX [X=attackIndex]
            attackIndex++;  //Aumenta o índice de ataque
            /*Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackpos.position, attackrange, inimigos);   //Nº de inimigos (cada entidade) no "círculo"
            for(int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
            }*/
            timesinceAttack = 0.0f;   //Recomeça a contar o tempo
        }
    }
}
