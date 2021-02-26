using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static int _coinPoints;
    private static int _minionPoints;
    private static Transform _coinUI;

    public static void GameEnd()
    {
        var currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
        _coinPoints = 0;
        _minionPoints = 0;
    }

    public static void InitializeCoinUi()
    {
        _coinUI = GameObject.Find("Canvas/Coin").transform.GetChild(0);
    }

    public static void AddCoinPoint()
    {
        _coinPoints++;
        UpdateCoinAmmount();
    }

    private static void UpdateCoinAmmount()
    {
        _coinUI.GetComponent<Text>().text = _coinPoints.ToString();
    }

    public static void AddMinionPoint()
    {
        _minionPoints++;
    }
}