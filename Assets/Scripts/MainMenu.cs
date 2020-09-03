using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{


    public void ClickStart()
    {
        AudioManagerDemo.instance.PlaySound(AudioClipss.Button);
        Debug.Log("Scene Loaded");
        SceneManager.LoadScene("GameScene");
    }

    public void ClickInstructions()
    {
        AudioManagerDemo.instance.PlaySound(AudioClipss.Button);
        Debug.Log("Instructions");
        SceneManager.LoadScene("Instructions");
    }

    public void ClickCredits()
    {
        AudioManagerDemo.instance.PlaySound(AudioClipss.Button);
        Debug.Log("Credits");
        SceneManager.LoadScene("Credits");
    }

    public void ClickMainMenu()
    {
        AudioManagerDemo.instance.PlaySound(AudioClipss.Button);
        Debug.Log("StartMenu");
        SceneManager.LoadScene("StartScreen");
    }

    public void QuitGame()
    {
        AudioManagerDemo.instance.PlaySound(AudioClipss.Button);
        Application.Quit();
    }
}
