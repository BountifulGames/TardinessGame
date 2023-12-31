using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{

    public void Play()
    {
        SceneManager.LoadScene("Level-1");
    }

    public void Help()
    {
        SceneManager.LoadScene("Help");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit game");
    }

}
