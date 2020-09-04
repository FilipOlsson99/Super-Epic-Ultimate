using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EscapeMenu : MonoBehaviour
{
    public static bool isGamePaused = false;
    public GameObject PauseCanvas;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }


    public void ResumeGame()
    {
        PauseCanvas.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }


    private void PauseGame()
    {
        PauseCanvas.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("QUIT");

    }

}


