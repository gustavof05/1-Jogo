using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreLoad : MonoBehaviour
{
    public Text scoreText;  
    // Start is called before the first frame update
    void Start()
    {
    GameController.instance.scoreText = scoreText;         
    GameController.instance.UpdateScoreText(); // Atualizar o texto do score     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
    
       

