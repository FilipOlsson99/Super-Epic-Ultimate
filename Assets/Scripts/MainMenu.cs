using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ClickStart()
    {
        Debug.Log("Scene Loaded");
        SceneManager.LoadScene("the o");
    }

    public void ClickInstructions()
    {
        Debug.Log("Instructions");
        SceneManager.LoadScene("Instructions");
    }

    public void ClickMainMenu()
    {
        Debug.Log("StartMenu");
        SceneManager.LoadScene("StartScreen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
