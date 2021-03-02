﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("PlayableScene");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public static void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}