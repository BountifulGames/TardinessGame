using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor.SearchService;

public class Timer : MonoBehaviour
{
    public float timerStartValue = 90;
    private float timeValue;
    public TMP_Text timerText;
    private float minutes;
    private float seconds;
    private string scene;


    private void Start()
    {
        GameManager.gm.timerOn = true;
        scene = SceneManager.GetActiveScene().name;

        if (GameManager.gm.isCheckpoint)
        {
            if (scene == "Level-1")
            { 
            timeValue = (GameManager.gm.levelOneMin *60 + GameManager.gm.levelOneSec);
                Debug.Log(timeValue);
            }
            else if (scene == "Level-2")
            {
                timeValue = (GameManager.gm.levelTwoMin * 60 + GameManager.gm.levelTwoSec);
                Debug.Log(timeValue);
            }
            else
            {
                Debug.Log("Timer scene error");
                Debug.Log(timeValue);
            }
        }
        else
        {
            timeValue = timerStartValue;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.gm.timerOn == true)
        {
            if (timeValue > 0)
            {
                timeValue -= Time.deltaTime;
            }
            else
            {
                //never display negative time value
                timeValue = 0;

                //run gameover method
            }

            DisplayTime(timeValue);
        }
        
    }

    void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }
        else if(timeToDisplay > 0)
        {
            timeToDisplay += 1;
        }

        //how many minutes remain
        minutes = Mathf.FloorToInt(timeToDisplay / 60);
        //remainder of seconds remain
        seconds = Mathf.FloorToInt(timeToDisplay % 60);

        //display text with proper formatting
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void RecordTime()
    {
        //gameManager
        Debug.Log(scene);

        if (scene == "Level-1")
        {
          GameManager.gm.levelOneMin = minutes;
          GameManager.gm.levelOneSec = seconds;
          GameManager.gm.levelOneGrade = GameManager.gm.currentGrade;
          Debug.Log(GameManager.gm.levelOneMin + "min");
          Debug.Log(GameManager.gm.levelOneSec + "sec");
        }
        else if (scene == "Level-2")
        {
                GameManager.gm.levelTwoMin = minutes;
                GameManager.gm.levelTwoSec = seconds;
                GameManager.gm.levelTwoGrade = GameManager.gm.currentGrade;
                Debug.Log(GameManager.gm.levelTwoMin + "min");
                Debug.Log(GameManager.gm.levelTwoSec + "sec");
        }
        else
        {
          Debug.Log("Record Time Error");
        }

    }
}
