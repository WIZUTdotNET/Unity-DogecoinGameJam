using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static int _coinPoints;
    private static int _highScore;

    private static int _coinMultiplier = 1;
    private static int _minionPoints;
    private static Transform _coinUI;


    private static bool _hasShield;

    public static void GameEnd()
    {
        SceneManager.LoadScene("DeadScene");
    }

    public static void ResetCoins()
    {
        _coinPoints = 0;
        _minionPoints = 0;
    }

    public static int GetHighScore()
    {
        return _highScore;
    }

    public static bool UpdateHighScore()
    {
        if (_coinPoints > _highScore)
        {
            _highScore = _coinPoints;
            return true;
        }

        return false;
    }

    public static void InitializeCoinUi()
    {
        _coinUI = GameObject.Find("Canvas/Coin").transform.GetChild(0);
    }

    public static void AddCoinPoint()
    {
        _coinPoints += _coinMultiplier;
        UpdateCoinAmount();
        PlayCollection();
    }

    public static int GetCoins()
    {
        return _coinPoints;
    }

    private static void UpdateCoinAmount()
    {
        _coinUI.GetComponent<TextMeshProUGUI>().text = _coinPoints.ToString();
    }

    public static void AddMinionPoint()
    {
        _minionPoints++;
        PlayCollection();
    }

    public static void UpdateCoinMultiplier(int multiplier)
    {
        _coinMultiplier = multiplier;
        PlayCollection();
    }

    public static void RestoreCoinMultiplier()
    {
        _coinMultiplier = 1;
    }

    public static bool IsShielded()
    {
        return _hasShield;
    }

    public static void GiveShield()
    {
        _hasShield = true;
        PlayCollection();
    }

    public static void DestroyShield()
    {
        _hasShield = false;
    }

    public static void PlayCollection()
    {
        string[] coinCollection = new[] {"coinCollection1", "coinCollection2"};
        GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>().Play(coinCollection[Random.Range(0, coinCollection.Length)]);
    }
}