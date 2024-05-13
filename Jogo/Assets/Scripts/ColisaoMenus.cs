using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisaoMenus : MonoBehaviour
{
    public Player pc;
 void OnCollisionEnter2D(Collision2D col_ground) //Ao colidir com o chão
    {
        if(col_ground.gameObject.layer == 7) //7 é o número da layer em que foi posta a camada
        {
            pc.isJumping = false;  //Para de saltar
            pc.isFalling = false;
            pc.anim.SetBool("jump", false);
            pc.anim.SetBool("fall", false);
        }
    }
        void OnCollisionExit2D(Collision2D col_ground)  //Ao sair do chão
    {
        if(col_ground.gameObject.layer == 7) //7 é o número da layer em que foi posta a camada
        {
            pc.isJumping = true;   //Começa a saltar
        }
    }
}
