using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string scene;

    public void NewGame()
    {
        SceneManager.LoadScene("Intro");
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
        Debug.Log("Game Exit");
        Application.Quit();
    }
}
