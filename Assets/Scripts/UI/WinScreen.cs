using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WinScreen : MonoBehaviour
{
    [Header("Text References")]
    public TMP_Text timeText;
    public TMP_Text timeTotalText;
    public TMP_Text extraCredit;
    public Animator ecAnim;
    public TMP_Text gradeText;
    public TMP_Text gradeAverageText;
    public TMP_Text finalScore;
    public TMP_Text letterGrade;
    public Animator lgAnim;
    private float totalMinutes;
    private float totalSeconds;
    private float gradeAverage;
    private float bonus;

    [Header("Times to beat")]
    public float hiTime;
    public float midTime;
    public float lowTime;

    [Header("Sound Array")]
    public AudioClip[] cheer;
    private int cheerValue;

    private void Start()
    {
        //combine scores from level one and two
        CalculateScore();
        //check time for extra credit bonus
        CalculateExtraCredit();
        //combine score + extra credit for final score
        FinalScore();
        //plays letter grade animation
        StartCoroutine(LetterGrade());

    }


    private void CalculateScore()
    {
        //calculate time elapsed stage 1
        float LevelOne = (GameManager.gm.levelOneMin * 60 + GameManager.gm.levelOneSec);
        //how many minutes remain
        float minutes1 = Mathf.FloorToInt(LevelOne / 60);
        //remainder of seconds
        float seconds1 = Mathf.FloorToInt(LevelOne % 60);


        //calculate time elapsed stage 2
        float LevelTwo = (GameManager.gm.levelTwoMin * 60 + GameManager.gm.levelTwoSec);
        //how many minutes remain
        float minutes2 = Mathf.FloorToInt(LevelTwo / 60);
        //remainder of seconds
        float seconds2 = Mathf.FloorToInt(LevelTwo % 60);

        totalMinutes = Mathf.FloorToInt((minutes1 + minutes2) + (seconds1 + seconds2) / 60);
        Debug.Log(totalMinutes + "total minutes");
        totalSeconds = Mathf.FloorToInt((seconds1 + seconds2) % 60);
        Debug.Log(totalSeconds + "total seconds");

        //display time text with proper formatting
        timeText.text = "Stage 1: " + string.Format("{0:00}:{1:00}", minutes1, seconds1) + "<br>" + "Stage 2: " + string.Format("{0:00}:{1:00}", minutes2, seconds2); 
        timeTotalText.text = "Total: " + string.Format("{0:00}:{1:00}", totalMinutes, totalSeconds);

        gradeAverage = (GameManager.gm.levelOneGrade + GameManager.gm.levelTwoGrade) / 2;

        //displays grade values
        gradeText.text = "Stage 1: " + GameManager.gm.levelOneGrade + "<br>" + "Stage 2: " + GameManager.gm.levelTwoGrade;
        gradeAverageText.text = "Average: " + gradeAverage;
    }

    private void CalculateExtraCredit()
    {
        //convert minutes and seconds into a single float
        float rawTime = (totalMinutes * 60) + totalSeconds;
        
        //extra credit bonuses based on hi mid and low time ranks
        if(rawTime >= hiTime)
        {
            bonus = 3;
        }
        else if(rawTime >= midTime)
        {
            bonus = 2;
        }
        else if(rawTime >= lowTime)
        {
            bonus = 1;
        }
        else
        {
            bonus = 0;
        }
        extraCredit.text = "Extra Credit: +" + bonus;
        ecAnim.SetFloat("ExtraCredit", bonus);

    }

    private void FinalScore()
    {
        float finalScoreValue = gradeAverage + bonus;
        finalScore.text = "Grade: " + finalScoreValue;

        if(finalScoreValue > 100)
        {
            letterGrade.text = "A+";
            //setting audio array value
            cheerValue = 0;
        }
        else if(finalScoreValue >= 90)
        {
            letterGrade.text = "A";
            //setting audio array value
            cheerValue = 1;
        }
        else if(finalScoreValue >= 80)
        {
            letterGrade.text = "B";
            //setting audio array value
            cheerValue = 2;
        }
        else if(finalScoreValue >= 70)
        {
            letterGrade.text = "C";
            //setting audio array value
            cheerValue = 3;
        }
        else if(finalScoreValue >= 60)
        {
            letterGrade.text = "D";
            //setting audio array value
            cheerValue = 4;
        }
        else
        {
            letterGrade.text = "F";
            //setting audio array value
            cheerValue = 5;
        }

    }

    IEnumerator LetterGrade()
    {
        //wait
        yield return new WaitForSeconds(1.5f);
        //play animation
        lgAnim.SetTrigger("FinalGrade");
        //wait again
        yield return new WaitForSeconds(.4f);
       // SoundManager.instance.PlaySound(cheer[cheerValue]);

    }


    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit game");
    }

}
