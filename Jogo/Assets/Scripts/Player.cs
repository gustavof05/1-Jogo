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
        if(Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0) anim.SetBool("walk", true);
        else anim.SetBool("walk", false);
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if(!isJumping)
            {
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                doubleJump = true;
            }
            else
            {
                if(doubleJump)
                {
                    rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col_ground)
    {
        if(col_ground.gameObject.layer == 8) //8 é o número da layer em que foi posta a camada do 'chão'
        {
            isJumping = false;
        }
    }

    void OnCollisionExit2D(Collision2D col_ground)
    {
        if(col_ground.gameObject.layer == 8) //8 é o número da layer em que foi posta a camada do 'chão'
        {
            isJumping = true;
        }
    }
}
