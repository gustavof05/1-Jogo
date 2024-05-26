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
            GameController.instance.UpdateScore(-15);
            PlayerPrefs.SetInt("score",GameController.instance.totalScore);
        }
    }

    void Death()
    {
        hdanim.SetTrigger("death");
        GameController.instance.UpdateScore(-300);
        PlayerPrefs.SetInt("score",GameController.instance.totalScore);
        isDead = true;  //Está morto
    }
}