using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisaoMenus : MonoBehaviour
{
    public Player p;
 void OnCollisionEnter2D(Collision2D col_ground) //Ao colidir com o chão
    {
        if(col_ground.gameObject.layer == 7) //7 é o número da layer em que foi posta a camada
        {
            p.isJumping = false;  //Para de saltar
            p.isFalling = false;
            p.anim.SetBool("jump", false);
            p.anim.SetBool("fall", false);
        }
    }
        void OnCollisionExit2D(Collision2D col_ground)  //Ao sair do chão
    {
        if(col_ground.gameObject.layer == 7) //7 é o número da layer em que foi posta a camada
        {
            p.isJumping = true;   //Começa a saltar
        }
    }
}
