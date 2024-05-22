using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAttack1 : MonoBehaviour
{
    public int phealth;
    public int pdamage;    //Dano tirado por ataque
    public Transform attackpos; //Posição de "ataque"
    public float attackrange;   //Range de ataque
    public LayerMask alvos;  //Camada onde estão os inimigos (para só "acertar" neles)
    private float timesinceAttack = 0.55f;   //Tempo desde o último ataque (inicial)
    private int attackIndex = 1;
    private Animator attanimp;
    public PlayerHurt_Death1 deathcontroller;
    [SerializeField] GameModeSelector1 gamemode1_2;

    // Start is called before the first frame update
    void Start()
    {
        attanimp = GetComponent<Animator>();
        gamemode1_2.gamemode1_1 = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timesinceAttack += Time.deltaTime;  //Conta o tempo
        if(!deathcontroller.isDead) Attack();//Se não estiver morto
    }

    void Attack()
    {
        if(gamemode1_2.gamemode1_1 == 1)
        {
            if(Input.GetKeyDown(KeyCode.KeypadEnter) && timesinceAttack > 0.55f) //É possível atacar após 0.55s do último ataque
            {
                if (attackIndex > 3) attackIndex = 1;   //Se tiver feito o 3ºataque, volta ao 1º
                if (timesinceAttack > 1.0f) attackIndex = 1;    //Se tiver passado 1s após o último ataque, volta ao 1º
                attanimp.SetTrigger("attack" + attackIndex); //"Dispara" o parâmetro attackX [X=attackIndex]
                attackIndex++;  //Aumenta o índice de ataque
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackpos.position, attackrange, alvos);   //Nº de alvos/inimigos (cada entidade) no "círculo"
                for(int i = 0; i < enemiesToDamage.Length; i++) enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(pdamage);
                timesinceAttack = 0.0f;   //Recomeça a contar o tempo
            }
        }
        else if(gamemode1_2.gamemode1_1 == 2)
        {
            if(Input.GetButtonDown("Attack Joystick 1") && timesinceAttack > 0.55f) //É possível atacar após 0.55s do último ataque
            {
                if (attackIndex > 3) attackIndex = 1;   //Se tiver feito o 3ºataque, volta ao 1º
                if (timesinceAttack > 1.0f) attackIndex = 1;    //Se tiver passado 1s após o último ataque, volta ao 1º
                attanimp.SetTrigger("attack" + attackIndex); //"Dispara" o parâmetro attackX [X=attackIndex]
                attackIndex++;  //Aumenta o índice de ataque
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackpos.position, attackrange, alvos);   //Nº de alvos/inimigos (cada entidade) no "círculo"
                for(int i = 0; i < enemiesToDamage.Length; i++) enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(pdamage);
                timesinceAttack = 0.0f;   //Recomeça a contar o tempo
            }
        }
    }
}
