using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class NewGame : MonoBehaviour
{
    public void Game()
    {
        SceneManager.LoadScene("maciej_scena");
        GameManager.HighScore();
        GameManager.ResetCoins();
        

    }
}
