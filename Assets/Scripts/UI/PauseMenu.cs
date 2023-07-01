using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;
    public TMP_Text soundText;
    public TMP_Text musicText;
    public Slider volumeSlider;
    public Button soundButton;
    public GameObject timerIcon;
    public GameObject grade;

    private float alpha;
    private Color timerCol;
    private Color gradeCol;

    private float soundValue;
    private float musicValue;

    // Update is called once per frame
    private void Start()
    {
        // alpha = 0.5f;

        //timerCol = GetComponent<RawImage>().color;
        // timerCol.a = alpha;
        // gradeCol = GetComponent<Renderer>().material.color;
        // gradeCol.a = alpha;

        soundValue = PlayerPrefs.GetFloat("soundVolume") * 100;
        soundText.text = "Sound: " + soundValue.ToString();

       musicValue = PlayerPrefs.GetFloat("musicVolume") * 100;
       musicText.text = "Music: " + soundValue.ToString();

    }

    void Update()
    {
        if (!GameManager.gm.playerMovement)
        {
            pauseMenuUI.SetActive(false);
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                ResetMenu();
                Resume();
            }
            else
            {
                Pause();
                //timerIcon.GetComponent<RawImage>().color.a = timerCol;
            }
        }
    }

    public void Resume()
        { 
            Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        gameIsPaused = false;
        }
        
        
    public void Sound()
    {
        SoundManager.instance.SoundVolume(0.2f);
        soundValue = PlayerPrefs.GetFloat("soundVolume") * 100;
        soundText.text = "Sound: " + soundValue.ToString();


        //ResetMenu();
        //soundButton.gameObject.SetActive(false);
        //volumeSlider.gameObject.SetActive(true);
    }

        
    public void Music()
    {
        //ResetMenu();

        SoundManager.instance.MusicVolume(0.2f);
        float volumeValue = PlayerPrefs.GetFloat("musicVolume") * 100;
        musicText.text = "Music: " + volumeValue.ToString();
    }


        
    public void LoadMenu()
    {
        Resume();
        GameManager.gm.isCheckpoint = false;
        SceneManager.LoadScene("MainMenu");
    }

        
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit game");
    }

        
    void Pause()
    {
            //turns on pause overlay
            pauseMenuUI.SetActive(true);
            //pause the game
            Time.timeScale = 0f;
            gameIsPaused = true;
    }

    public void Retry()
    {
        //get reference for current scene
        string currentScene = SceneManager.GetActiveScene().name;
        //reload current scene
        SceneManager.LoadScene(currentScene);
    }

    public void ChangeVolume()
    {
       // AudioListener.volume = volumeSlider.value;
    }

    public void ResetMenu()
    {
       // volumeSlider.gameObject.SetActive(false);
       // soundButton.gameObject.SetActive(true);


    }
    
}
