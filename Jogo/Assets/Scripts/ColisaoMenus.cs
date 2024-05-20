using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisaoMenus : MonoBehaviour
{
    public Player1 pc1;
    public Player2 pc2;
void OnCollisionEnter2D(Collision2D col_ground) //Ao colidir com o chão
    {
        if(col_ground.gameObject.layer == 7) //7 é o número da layer em que foi posta a camada
        {
            pc1.isJumping = false;  //Para de saltar
            pc1.isFalling = false;
            pc1.anim.SetBool("jump", false);
            pc1.anim.SetBool("fall", false);
            
            pc2.isJumping = false;  //Para de saltar
            pc2.isFalling = false;
            pc2.anim.SetBool("jump", false);
            pc2.anim.SetBool("fall", false);
        }
    }
        void OnCollisionExit2D(Collision2D col_ground)  //Ao sair do chão
    {
        if(col_ground.gameObject.layer == 7) //7 é o número da layer em que foi posta a camada
        {
            pc1.isJumping = true;
            pc2.isJumping = true;   //Começa a saltar
        }
    }
}