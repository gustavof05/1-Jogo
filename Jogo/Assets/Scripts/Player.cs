using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    public bool isJumping;
    public bool doubleJump;
    private Rigidbody2D rig;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
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
                    rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);  //Dar o Double Jump
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
            anim.SetBool("jump", false);
        }
    }

    void OnCollisionExit2D(Collision2D col_ground)  //Ao sair do chão
    {
        if(col_ground.gameObject.layer == 8) //8 é o número da layer em que foi posta a camada do 'chão'
        {
            isJumping = true;   //Começa a saltar
        }
    }
}
