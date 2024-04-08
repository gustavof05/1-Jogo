using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int ehealth = 13;
    public float speed = 3;
    private Animator anim;
    private float c = 0f
    public GameObject bloodEffect;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("walk", true);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Death();
    }

    void Move()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    /*void OnCollisionEnter2D(Collision2D col_ground) //Ao colidir com o chão
    {
        if(col_ground.gameObject.layer == 8) //8 é o número da layer em que foi posta a camada do 'chão'
        {
            isJumping = false;  //Para de saltar
            isFalling = false;
            anim.SetBool("jump", false);
            anim.SetBool("fall", false);
        } 
    }

    void OnCollisionExit2D(Collision2D col_ground)  //Ao sair do chão
    {
        if(col_ground.gameObject.layer == 8) //8 é o número da layer em que foi posta a camada do 'chão'
        {
            isJumping = true;   //Começa a saltar
        }
    }*/

    public void TakeDamage(int damage)
    {
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        ehealth -= damage;
        Debug.Log("damage taken");
    }

    public void Death()
    {
        if(ehealth <= 0)
        {
            anim.SetTrigger("death");
            c += Time.deltaTime;
            if(c == 500f) 
            {
                Destroy(gameObject);   //Desaparecimento do inimigo
                c = 0f;
            }
        }
    }
}
