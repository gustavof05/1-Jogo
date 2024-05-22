using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class PlayerHurt_Death2 : MonoBehaviour
{
    private Animator hdanim;
    public bool isDead = false;
    public PlayerAttack2 p2;

    // Start is called before the first frame update
    void Start()
    {
        hdanim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isDead && (p2.phealth <= 0)) Death();
    }

    public void TakeDamage(int edamage)
    {
        if(!isDead)
        {
            p2.phealth -= edamage;
            hdanim.SetTrigger("hurt");
            GameController.instance.totalScore -= 15;
            GameController.instance.UpdateScoreText();
        }
    }

    void Death()
    {
        GameController.instance.totalScore -= 300;
        GameController.instance.UpdateScoreText();
        hdanim.SetTrigger("death");
        isDead = true;  //Está morto
    }
}