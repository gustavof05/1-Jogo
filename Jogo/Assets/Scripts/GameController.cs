using System.Collections;
 using System.Collections.Generic; 
 using UnityEngine; 
 using UnityEngine.UI;  
 public class GameController : MonoBehaviour 
 {     
    public int totalScore;     
    public Text scoreText;     
    public static GameController instance;      
    void Awake()     
    {         
        if (instance == null)         
        {             
            instance = this;             
            DontDestroyOnLoad(gameObject); // Persistir o GameController entre cenas         
            }         
            else         
            {             Destroy(gameObject); // Destruir duplicatas do GameController         
            }     
            }      
            void Start()     
            {         
                UpdateScoreText();     
            }      
public void UpdateScoreText()     
{         
    if (scoreText != null)         
    {             
        scoreText.text = totalScore.ToString();         
    }     
                        }      
                        public void UpdateScore(int score)     
                        {         
                            totalScore += score;         
                            UpdateScoreText();     
                        } 
}