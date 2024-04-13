using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColisoesPlayerMenu : MonoBehaviour
{
    void Start()
    {   
        // Desativar OptionsPanel no início
        OptionsPanel.SetActive(false);
    }
    public GameObject OptionsPanel; 
    public GameObject MainMenu; 
    public GameObject Levels;
    public float delay = 0.5f;

    [SerializeField] private GameObject _object;
    [SerializeField] private AudioClip[] WoodSound;

void OnCollisionEnter2D(Collision2D col_ground)
{
    Vector2 contactNormal = col_ground.GetContact(0).normal;

    // Verifica se a normal da colisão está apontando para cima
    if (contactNormal.y < 0)
    {
        if(col_ground.gameObject.name == "Start")
        {           
            //SoundEfects.instance.PlaySoundFxClip(WoodSound, transform, 1f);
            SoundEfects.instance.PlayRandomSoundFxClip(WoodSound, transform, 1f);
            Invoke("delayFunc",delay);
            MainMenu.SetActive(false);
        }
        if(col_ground.gameObject.name == "Options")
        {
            SoundEfects.instance.PlayRandomSoundFxClip(WoodSound, transform, 1f);
            MainMenu.SetActive(false);
            OptionsPanel.SetActive(true);
            Debug.Log("Ativando");
        }
        if(col_ground.gameObject.name == "Quit")
        {
            Application.Quit();
            Debug.Log("Game is exiting");
        }
        if(col_ground.gameObject.name == "Cancel")
        {
            SoundEfects.instance.PlayRandomSoundFxClip(WoodSound, transform, 1f);
            Levels.SetActive(false);
            MainMenu.SetActive(true);
        }
        if(col_ground.gameObject.name == "Level 1")
        {
            SoundEfects.instance.PlayRandomSoundFxClip(WoodSound, transform, 1f);
            SceneManager.LoadScene("Nivel 1");
        }
        if(col_ground.gameObject.name == "Level 2")
        {
            SoundEfects.instance.PlayRandomSoundFxClip(WoodSound, transform, 1f);
            SceneManager.LoadScene("LevelTwo");
        }
        if(col_ground.gameObject.name == "Level 3")
        {
            SoundEfects.instance.PlayRandomSoundFxClip(WoodSound, transform, 1f);
            SceneManager.LoadScene("LevelThree");
        }
    }
}
    void delayFunc()
    {
        Levels.SetActive(true);
        Debug.Log("Delay");
    }
}
