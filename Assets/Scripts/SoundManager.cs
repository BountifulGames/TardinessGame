using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }
    private AudioSource audioSource;
    private AudioSource musicSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        musicSource =transform.GetChild(0).GetComponent<AudioSource>();

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }

        //set initial volumes
        SoundVolume(0);
        MusicVolume(0);
    }

    public void PlaySound(AudioClip _sound, float _scale)
    {
        //plays sound effect once
        audioSource.PlayOneShot(_sound, _scale);
    }

    public void SoundVolume (float _change)
    {
        //get base volume
        float baseVolume = 1;
        
        //get value of volume and change it
        float currentVolume = PlayerPrefs.GetFloat("soundVolume", 1);
        currentVolume += _change;

        //loop around to 1 or 0 if max-min hit
        if(currentVolume > 1)
        {
            currentVolume = 0;
        }
        else if(currentVolume < 0)
        {
            currentVolume = 1;
        }

        //assign value
        float finalVolume = currentVolume * baseVolume;
        audioSource.volume = finalVolume;
        
        PlayerPrefs.SetFloat("soundVolume", currentVolume);
        
    }

    public void MusicVolume(float _change)
    {
        //get base volume
        float baseVolume = .3f;

        //get value of volume and change it
        float currentVolume = PlayerPrefs.GetFloat("musicVolume", 1);
        currentVolume += _change;

        //loop around to 1 or 0 if max-min hit
        if (currentVolume > 1)
        {
            currentVolume = 0;
        }
        else if (currentVolume < 0)
        {
            currentVolume = 1;
        }

        //assign value
        float finalVolume = currentVolume * baseVolume;
        musicSource.volume = finalVolume;

        PlayerPrefs.SetFloat("musicVolume", currentVolume);
    }
}
