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

    //public float delay = 0.5f;
    public Animator DescerLMenu;
    public Animator DescerMMenu;

    public Animator DescerOMenu;

    [SerializeField] private GameObject _object;
    [SerializeField] private AudioClip[] WoodSound;
    public LevelsMenu menu;

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
            //Invoke("delayFunc",delay); // Fazer funçao de delay
            MainMenu.SetActive(false);
            Levels.SetActive(true);
            DescerLMenu.SetFloat("DescerLMenu",1);
        }
        if(col_ground.gameObject.name == "Options")
        {
            SoundEfects.instance.PlayRandomSoundFxClip(WoodSound, transform, 1f);
            MainMenu.SetActive(false);
            OptionsPanel.SetActive(true);
            DescerOMenu.SetFloat("DescerOMenu",1);
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
            DescerMMenu.SetFloat("DescerMMenu",1);
        }
        if(col_ground.gameObject.name == "Level 1")
        {
            SoundEfects.instance.PlayRandomSoundFxClip(WoodSound, transform, 1f);
            menu.LoadLevel("Nivel 1_teste");
        }
        if(col_ground.gameObject.name == "Level 2")
        {
            SoundEfects.instance.PlayRandomSoundFxClip(WoodSound, transform, 1f);
            menu.LoadLevel("LevelTwo");
        }
        if(col_ground.gameObject.name == "Level 3")
        {
            SoundEfects.instance.PlayRandomSoundFxClip(WoodSound, transform, 1f);
            menu.LoadLevel("LevelThree");
        }
    }
}
    /*void delayFunc() //Funçao para fazer delay
    {
        Levels.SetActive(true);
        Debug.Log("Delay");
    }*/
}
