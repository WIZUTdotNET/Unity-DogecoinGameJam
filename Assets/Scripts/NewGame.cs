using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class NewGame : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey("space"))
        {
            Game();
        }
    }
    public void Game()
    {

        SceneManager.LoadScene("maciej_scena");
        GameManager.ResetCoins();
         
    }
}