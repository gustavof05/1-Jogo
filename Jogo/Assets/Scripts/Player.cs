using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    public bool isJumping;
    public bool doubleJump;
    public bool isFalling;
    private Rigidbody2D rig;
    private Animator anim;
    public PlayerHurt_Death deathcontroller;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!deathcontroller.isDead) //Se não estiver morto
        {
            Move();
            Jump();
            UpdateAnimations();
        }
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;
        if(Input.GetAxis("Horizontal") > 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);    //Mexer no eixo posicional do player
        }
        else if(Input.GetAxis("Horizontal") < 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);  //Mexer no eixo posicional do player
        }
        else anim.SetBool("walk", false);
        if (rig.velocity.y < 0) isFalling = true;   //Se velocidade em y for negativa, está a cair
        else isFalling = false;
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump")) //Ao "clicar" no saltar
        {
            if(!isJumping)  //Se não estiver a saltar
            {
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);  //O player salta
                anim.SetBool("jump", true);
                doubleJump = true;  //É permitido dar Double Jump (opção desbloqueada)
            }
            else
            {
                if(doubleJump)  //Se ativar o Double Jump
                {
                    rig.AddForce(new Vector2(0f, JumpForce/3), ForceMode2D.Impulse);  //Dar o Double Jump
                    //anim.SetBool("jump", true); /*NÃO FUNCIONA*/
                    doubleJump = false; //Não é permitido dar (outra vez) Double Jump (opção bloqueada)
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col_ground) //Ao colidir com o chão
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
    }

    void UpdateAnimations()
    {
        // Lógica para atualizar as animações com base no estado de salto e queda
        if (isJumping)  //Se estiver a saltar (sair do ground), verifica se está a cair, ou a saltar
        {
            if (isFalling)  //Se estiver a cair
            {
                anim.SetBool("jump", false); // Desativa a animação de subida
                anim.SetBool("fall", true);  // Ativa a animação de queda
            }
            else
            {
                anim.SetBool("fall", false); // Desativa a animação de queda
                anim.SetBool("jump", true);  // Ativa a animação de subida
            }
        }
        else
        {
            anim.SetBool("jump", false);
            anim.SetBool("fall", false);
        }
    }
}
