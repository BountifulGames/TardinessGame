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

    // Update is called once per frame
    private void Start()
    {
        alpha = 0.5f;

        timerCol = GetComponent<RawImage>().color;
        timerCol.a = alpha;
        gradeCol = GetComponent<Renderer>().material.color;
        gradeCol.a = alpha;
        
    }

    void Update()
    {
        if(!GameManager.gm.playerMovement)
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
            ResetMenu();
            pauseMenuUI.SetActive(false);
            //game time back to default
            Time.timeScale = 1f;
            gameIsPaused = false;
        }
        
        
    public void Sound()
    {
        ResetMenu();
        soundButton.gameObject.SetActive(false);
        volumeSlider.gameObject.SetActive(true);
    }

        
    public void Music()
    {
        ResetMenu();
        musicText.text = "Music: ";
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
        AudioListener.volume = volumeSlider.value;
    }

    public void ResetMenu()
    {
        volumeSlider.gameObject.SetActive(false);
        soundButton.gameObject.SetActive(true);


    }
    
}
