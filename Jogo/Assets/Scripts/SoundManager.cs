using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider slider1;
    [SerializeField] private Slider slider2;
    [SerializeField] private Slider slider3;

    private void Start()
    {
        if (PlayerPrefs.HasKey("master") || PlayerPrefs.HasKey("Fx") || PlayerPrefs.HasKey("AmbientVolume"))
        {
            LoadVolume();
        }else
        {
            SetMasterVolume();
            SetFXVolume();
            SetAmbientVolume();
        }
    }
    public void SetMasterVolume()
    {
        float level = slider1.value;
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(level)*20);
        PlayerPrefs.SetFloat("master", level);
    }
    public void SetFXVolume()
    {
        float level = slider2.value;
        audioMixer.SetFloat("SoundFx", Mathf.Log10(level)*20);
        PlayerPrefs.SetFloat("Fx", level);

    }

    public void SetAmbientVolume()
    {
        float level = slider3.value;
        audioMixer.SetFloat("Ambient", Mathf.Log10(level)*20);
        PlayerPrefs.SetFloat("AmbientVolume", level);

    }
    private void LoadVolume()
    {
        slider1.value = PlayerPrefs.GetFloat("master");
        SetMasterVolume();
        slider2.value = PlayerPrefs.GetFloat("Fx");
        SetFXVolume();
        slider3.value = PlayerPrefs.GetFloat("AmbientVolume");
        SetAmbientVolume();
    }
}
