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
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player1") player1Collided = true;
        else if(collider.gameObject.tag == "Player2") player2Collided = true;
        if(player1Collided && player2Collided) 
        {
            if(SceneManager.GetActiveScene().buildIndex + 1 != 3)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
            SceneManager.LoadScene("MainMenu");
            }
        }
     

        if(controller1.isDead && !controller2.isDead && player2Collided)
        {
            if(SceneManager.GetActiveScene().buildIndex + 1 != 3)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
            SceneManager.LoadScene("MainMenu");
            }
        }
        if(!controller1.isDead && controller2.isDead && player1Collided)
        {
            if(SceneManager.GetActiveScene().buildIndex + 1 != 3)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
            SceneManager.LoadScene("MainMenu");
            }
        }
        if(!controller2.p2.isActiveAndEnabled && player1Collided )
        {
            if(SceneManager.GetActiveScene().buildIndex + 1 != 3)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
            SceneManager.LoadScene("MainMenu");
            }
        }


    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player1") player1Collided = false;
        else if(collider.gameObject.tag == "Player2") player2Collided = false;
    }
}
