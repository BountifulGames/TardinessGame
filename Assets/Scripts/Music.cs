using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    public AudioClip stage1;
    public AudioClip stage2;
    public AudioClip menu;

    private AudioSource music;

    // Start is called before the first frame update
    void Start()
    {
        music = GetComponent<AudioSource>();
        ChangeMusic();
    }


    // Update is called once per frame
    void Update()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ChangeMusic();
    }

    void ChangeMusic()
    {
        if (SceneManager.GetActiveScene().name == "Level-1")
        {
            music.clip = stage1;
            
        }
        else if (SceneManager.GetActiveScene().name == "Level-2")
        {
            music.clip = stage2;
        }
        else if (SceneManager.GetActiveScene().name == "MainMenu" || SceneManager.GetActiveScene().name == "Win")
        {
            if (music.clip == menu)
            {
                return;
            }
            else
            {
                music.clip = menu;
            }
        }
        else
        {
            return;
        }
        
        music.Play();
    }
}
