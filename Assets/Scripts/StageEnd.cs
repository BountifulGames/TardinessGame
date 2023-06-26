using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageEnd : MonoBehaviour
{

    private GameObject timer;
    public AudioClip bell;
    public TMP_Text recordTime;
    public AudioSource source;

    private void Awake()
    {
        timer = GameObject.Find("Timer");
        source = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Scene currentScene = SceneManager.GetActiveScene();  //load current scene name
        string sceneName = currentScene.name;

        if (collision.tag == "Player")
        {
            StartCoroutine(LevelTransition());
            SoundManager.instance.GetComponent<AudioSource>().PlayOneShot(bell, 0.5f);
            timer.GetComponent<Timer>().RecordTime();

        }
    }

    private IEnumerator LevelTransition()
    {
        yield return new WaitForSeconds(3);

        if (SceneManager.GetActiveScene().name == "Level-1")
        {
            SceneManager.LoadScene("Level-2");
        }
        if (SceneManager.GetActiveScene().name == "Level-2")
        {
            SceneManager.LoadScene("Win");
        }

    }
}
