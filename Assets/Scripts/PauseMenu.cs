using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenu;
    public GameObject gameMaster;

    

    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    private void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Destroy(gameMaster);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void Quit()
    {
        Debug.Log("Game Exit");
        Application.Quit();
    }

    public void Options()
    {

    }

}
