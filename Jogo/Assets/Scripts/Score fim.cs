using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scorefim : MonoBehaviour
{
        public Text scoreText;  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    GameController.instance.scoreText = scoreText;         
    GameController.instance.UpdateScoreText(); // Atualizar o texto do score 
    }
}
