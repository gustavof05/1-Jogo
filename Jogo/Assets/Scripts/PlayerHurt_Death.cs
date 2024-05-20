using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class PlayerHurt_Death : MonoBehaviour
{
    public int dtp = 15;
    private Animator hdanim;
    public bool isDead = false;
    public PlayerAttack1 p1;
    public PlayerAttack2 p2;

    // Start is called before the first frame update
    void Start()
    {
        hdanim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isDead && (p1.phealth <= 0)) Death();
        if(!isDead && (p2.phealth <= 0)) Death();
    }

    public void TakeDamage(int edamage)
    {
        if(!isDead)
        {
            p1.phealth -= edamage; //Vida do player1 perde o valor do dano do inimigo
            p2.phealth -= edamage;
            hdanim.SetTrigger("hurt");
            GameController.instance.totalScore -= dtp;
            GameController.instance.UpdateScoreText();
        }
    }

    void Death()
    {
        GameController.instance.totalScore = 0;
        GameController.instance.UpdateScoreText();
        hdanim.SetTrigger("death");
        isDead = true;  //Está morto
    }          
}
