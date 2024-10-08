using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int Score;   
     [SerializeField] private AudioClip coinsound;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player1" || collider.gameObject.tag == "Player2")
        {
            GameController.instance.totalScore += Score;
            GameController.instance.UpdateScoreText();
            SoundEfects.instance.PlaySoundFxClip(coinsound,transform,1f);
            Destroy(gameObject);
        }
    }
}