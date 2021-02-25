using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenager : MonoBehaviour
{
    private static int _points;
    private static Transform _coinUI = GameObject.Find("Canvas/Coin").transform.GetChild(0);

    public static void GameEnd()
    {
        var currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
        _points = 0;
    }

    public static void AddPoint()
    {
        _points++;
        UpdateCoinAmmount();
    }
    
    private static void UpdateCoinAmmount()
    {
        _coinUI.GetComponent<Text>().text = _points.ToString();
    }
}