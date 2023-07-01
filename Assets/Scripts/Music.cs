using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    public AudioClip stage1;
    public AudioClip stage2;
    
    // Start is called before the first frame update
    void Start()
    {
        AudioSource music = GetComponent<AudioSource>();

        if (SceneManager.GetActiveScene().name == "Level-1")
        {
            music.clip = stage1;
        }
        else if(SceneManager.GetActiveScene().name == "Level-2")
        {
            music.clip = stage2;
        }
        else
        {
            Debug.Log("Music stage error");
        }

        music.Play();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

}
