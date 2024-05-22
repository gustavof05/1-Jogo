using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassadeFase : MonoBehaviour
{
    private bool player1Collided = false;
    private bool player2Collided = false;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player1") player1Collided = true;
        else if(collider.gameObject.tag == "Player2") player2Collided = true;
        if(player1Collided && player2Collided) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player1") player1Collided = false;
        else if(collider.gameObject.tag == "Player2") player2Collided = false;
    }
}
