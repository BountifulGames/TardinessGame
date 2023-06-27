using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    [Header("Grade & Timer")]
    public float currentGrade;
    public bool timerOn;

    [Header("Score")]
    public float levelOneMin;
    public float levelTwoMin;
    public float levelOneSec;
    public float levelTwoSec;
    public float levelOneGrade;
    public float levelTwoGrade;

    [Header("Checkpoint")]
    public Vector2 checkpointLocation;

    private void Awake()
    {
        if (gm == null)
        {
            gm = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (gm != this)
        {
            Destroy(gameObject);
        }
    }

    public void LevelTwo()
    {
        SceneManager.LoadScene("Level2");
    }

    public void WinScene()
    {
        SceneManager.LoadScene("Win");
    }
}
