using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SoundEfects : MonoBehaviour
{
    public static SoundEfects instance;
    [SerializeField] private AudioClip[] WoodSound;


    [SerializeField] private AudioSource soundFxObject;

    private void Awake()
    {
        if (instance == null)
        instance = this;  
    }

    public void PlaySoundFxClip(AudioClip audioclip, Transform spawnTransform, float volume)
    {
        //spawn in gameobject

        AudioSource audioSource = Instantiate(soundFxObject, spawnTransform.position, Quaternion.identity);

        //assign the audioclip
        
        audioSource.clip = audioclip;

        //assign volume
        
    	audioSource.volume = volume;

        //play sound

        audioSource.Play();

        //get length of sound Fx clip

        float clipLength = audioSource.clip.length;

        //destroy the clip after it is done playing

        Destroy(audioSource.gameObject, clipLength);
    }
        public void PlayRandomSoundFxClip(AudioClip[] audioclip, Transform spawnTransform, float volume)
    {
        //assign a random index
        int rand = Random.Range(0, audioclip.Length);

        //spawn in gameobject

        AudioSource audioSource = Instantiate(soundFxObject, spawnTransform.position, Quaternion.identity);

        //assign the audioclip
        
        audioSource.clip = audioclip[rand];

        //assign volume
        
    	audioSource.volume = volume;

        //play sound

        audioSource.Play();

        //get length of sound Fx clip

        float clipLength = audioSource.clip.length;

        //destroy the clip after it is done playing

        Destroy(audioSource.gameObject, clipLength);
    }
    public void playsounds()
    {
        SoundEfects.instance.PlayRandomSoundFxClip(WoodSound, transform, 1f);

    }
}
