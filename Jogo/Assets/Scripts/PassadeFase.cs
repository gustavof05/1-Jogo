using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassadeFase : MonoBehaviour
{
    private bool player1Collided = false;
    private bool player2Collided = false;
    public PlayerHurt_Death1 controller1;
    public PlayerHurt_Death2 controller2;
    public Coins score;
    public Animator transition;
    public float transitiontime = 1f;
    public GameObject menu;

void Start ()
{
    menu.SetActive(false);
}
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player1") player1Collided = true;
        else if(collider.gameObject.tag == "Player2") player2Collided = true;
        if(player1Collided && player2Collided) 
        {
            if(SceneManager.GetActiveScene().buildIndex + 1 != 3)
            {
                StartCoroutine(Load(SceneManager.GetActiveScene().buildIndex + 1));

            }
            else
            {
                menu.SetActive(true);
                StartCoroutine(Load(0));
              
            }
        }
     

        if(controller1.isDead && !controller2.isDead && player2Collided)
        {
            if(SceneManager.GetActiveScene().buildIndex + 1 != 3)
            {
                StartCoroutine(Load(SceneManager.GetActiveScene().buildIndex + 1));
           
            }
            else
            {
                                menu.SetActive(true);

                StartCoroutine(Load(0));
          
            }
        }
        if(!controller1.isDead && controller2.isDead && player1Collided)
        {
            if(SceneManager.GetActiveScene().buildIndex + 1 != 3)
            {
                StartCoroutine(Load(SceneManager.GetActiveScene().buildIndex + 1));
         
            }
            else
            {
                                menu.SetActive(true);

                StartCoroutine(Load(0));
         
            }
        }
        if(!controller2.p2.isActiveAndEnabled && player1Collided )
        {
            if(SceneManager.GetActiveScene().buildIndex + 1 != 3)
            {
                StartCoroutine(Load(SceneManager.GetActiveScene().buildIndex + 1));
       
            }
            else
            {
                                menu.SetActive(true);

                StartCoroutine(Load(0));
          
            }
        }
    }
    IEnumerator Load(int Sceneindex)
    {
        transition.SetTrigger("start");
        yield return new WaitForSeconds(transitiontime);
        SceneManager.LoadScene(Sceneindex);
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player1") player1Collided = false;
        else if(collider.gameObject.tag == "Player2") player2Collided = false;
    }
}
