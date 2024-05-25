using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack2 : MonoBehaviour
{
    public int phealth;
    public int pdamage;    //Dano tirado por ataque
    public Transform attackpos; //Posição de "ataque"
    public float attackrange;   //Range de ataque
    public LayerMask alvos;  //Camada onde estão os inimigos (para só "acertar" neles)
    private float timesinceAttack = 0.55f;   //Tempo desde o último ataque (inicial)
    private int attackIndex = 1;
    private Animator attanimp;
    public PlayerHurt_Death2 deathcontroller;
    [SerializeField] GameModeSelector2 gamemode2_2;

    [SerializeField] private AudioClip[] sword1;

     [SerializeField] private AudioClip sword2;

     [SerializeField] private AudioClip[] sword3;

    // Start is called before the first frame update
    void Start()
    {
        attanimp = GetComponent<Animator>();
        gamemode2_2.gamemode2_1 = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timesinceAttack += Time.deltaTime;  //Conta o tempo
        if(!deathcontroller.isDead) Attack();//Se não estiver morto
    }

    void Attack()
    {
        if(gamemode2_2.gamemode2_1 == 1)
        {
            if(Input.GetKeyDown(KeyCode.Space) && timesinceAttack > 0.55f) //É possível atacar após 0.55s do último ataque
            {
                if (attackIndex > 3) attackIndex = 1;   //Se tiver feito o 3ºataque, volta ao 1º
                if (timesinceAttack > 1.0f) attackIndex = 1;    //Se tiver passado 1s após o último ataque, volta ao 1º
                attanimp.SetTrigger("attack" + attackIndex); //"Dispara" o parâmetro attackX [X=attackIndex]

                if (attackIndex == 1){SoundEfects.instance.PlayRandomSoundFxClip(sword1,transform,1f);}
                else if (attackIndex == 2){SoundEfects.instance.PlaySoundFxClip(sword2,transform,1f);}
                else{SoundEfects.instance.PlayRandomSoundFxClip(sword3,transform,1f);}

                attackIndex++;  //Aumenta o índice de ataque
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackpos.position, attackrange, alvos);   //Nº de alvos/inimigos (cada entidade) no "círculo"
                for(int i = 0; i < enemiesToDamage.Length; i++) enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(pdamage);
                timesinceAttack = 0.0f;   //Recomeça a contar o tempo
            }
        }
        else if(gamemode2_2.gamemode2_1 == 2)
        {
            if(Input.GetButtonDown("Attack Joystick 2") && timesinceAttack > 0.55f) //É possível atacar após 0.55s do último ataque
            {
                if (attackIndex > 3) attackIndex = 1;   //Se tiver feito o 3ºataque, volta ao 1º
                if (timesinceAttack > 1.0f) attackIndex = 1;    //Se tiver passado 1s após o último ataque, volta ao 1º
                attanimp.SetTrigger("attack" + attackIndex); //"Dispara" o parâmetro attackX [X=attackIndex]

                if (attackIndex == 1){SoundEfects.instance.PlayRandomSoundFxClip(sword1,transform,1f);}
                else if (attackIndex == 2){SoundEfects.instance.PlaySoundFxClip(sword2,transform,1f);}
                else{SoundEfects.instance.PlayRandomSoundFxClip(sword3,transform,1f);}

                attackIndex++;  //Aumenta o índice de ataque
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackpos.position, attackrange, alvos);   //Nº de alvos/inimigos (cada entidade) no "círculo"
                for(int i = 0; i < enemiesToDamage.Length; i++) enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(pdamage);
                timesinceAttack = 0.0f;   //Recomeça a contar o tempo
            }
        }
    }
}
