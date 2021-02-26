using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("albert_scene");
    }

    public void Settings()
    {
        throw new NotImplementedException();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("albert_MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}