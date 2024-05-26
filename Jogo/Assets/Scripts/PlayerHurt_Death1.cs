using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class PlayerHurt_Death1 : MonoBehaviour
{
    private Animator hdanim;
    public bool isDead = false;
    public PlayerAttack1 p1;

    // Start is called before the first frame update
    void Start()
    {
        hdanim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isDead && (p1.phealth <= 0)) Death();
    }

    public void TakeDamage(int edamage)
    {
        if(!isDead)
        {
            p1.phealth -= edamage; //Vida do player1 perde o valor do dano do inimigo
            hdanim.SetTrigger("hurt");
            PlayerPrefs.SetInt("score",GameController.instance.totalScore);
            GameController.instance.UpdateScore(-15);
        }
    }

    void Death()
    {
        hdanim.SetTrigger("death");
        PlayerPrefs.SetInt("score",GameController.instance.totalScore);
        GameController.instance.UpdateScore(-300);
        isDead = true;  //Está morto
    }          
}