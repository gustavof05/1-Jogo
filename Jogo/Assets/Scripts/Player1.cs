using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player1 : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    public bool isJumping;
    public bool doubleJump;
    public bool isFalling;
    private Rigidbody2D rig;
    public Animator anim;
    public PlayerHurt_Death deathcontroller;
    [SerializeField] GameModeSelector1 gamemodecontroller1;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
        gamemodecontroller1.gamemode1_1 = PlayerPrefs.GetInt("controller");
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
        float move1 = Input.GetAxis("Horizontal Joystick 1");
        float move2 = Input.GetAxis("Horizontal 1");
        if(gamemodecontroller1.gamemode1_1 == 1)
        {
            if(move2 != 0f)
            {
                Vector3 movement1 = new Vector3(move2, 0f, 0f);
                transform.position += movement1 * Time.deltaTime * Speed;
                if(move2 > 0f)
                {
                    anim.SetBool("walk", true);
                    transform.eulerAngles = new Vector3(0f, 0f, 0f);    //Mexer no eixo posicional do player
                }
                else if(move2 < 0f)
                {
                    anim.SetBool("walk", true);
                    transform.eulerAngles = new Vector3(0f, 180f, 0f);  //Mexer no eixo posicional do player
                }
            }
            else anim.SetBool("walk", false);
        }
        else if(gamemodecontroller1.gamemode1_1 == 2)
        {
            if(move1 != 0f)
            {
                Vector3 movement1 = new Vector3(move1, 0f, 0f);
                transform.position += movement1 * Time.deltaTime * Speed;
                if(move1 > 0f)
                {
                    anim.SetBool("walk", true);
                    transform.eulerAngles = new Vector3(0f, 0f, 0f);    //Mexer no eixo posicional do player
                }
                else if(move1 < 0f)
                {
                    anim.SetBool("walk", true);
                    transform.eulerAngles = new Vector3(0f, 180f, 0f);  //Mexer no eixo posicional do player
                }
            }
            else anim.SetBool("walk", false);
        } 
        if (rig.velocity.y < 0) isFalling = true;   //Se velocidade em y for negativa, está a cair
        else isFalling = false;
    }

    void Jump()
    {
        if(gamemodecontroller1.gamemode1_1 == 1)
        {
            if(Input.GetKeyDown(KeyCode.UpArrow)) //Ao "clicar" no saltar
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
        else if (gamemodecontroller1.gamemode1_1 == 2)
        {
            if(Input.GetButtonDown("Jump Joystick 1")) //Ao "clicar" no saltar
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
        if(col_ground.gameObject.layer == 8) isJumping = true;  //Começa a saltar //8 é o número da layer em que foi posta a camada do 'chão'
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
