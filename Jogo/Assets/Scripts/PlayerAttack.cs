using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeforAttack;    //Cooldown de cada ataque
    public float starttimeforAttack;
    // Update is called once per frame
    void Update()
    {
        if(timeforAttack <= 0)  //É possível atacar
        {
            if(Input.GetMouseButtonDown(0))
            {
                
            }
            timeforAttack = starttimeforAttack;
        }
        else
        {
            timeforAttack -= Time.deltaTime;
        }
    }
}
