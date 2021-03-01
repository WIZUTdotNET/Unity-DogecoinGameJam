using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static int _coinPoints;
    private static int _coinMultiplier = 1;
    private static int _minionPoints;
    private static Transform _coinUI;
    

    private static bool _hasShield;

    public static void GameEnd()
    {
        
        var currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("DeadScene");
        _coinPoints = 0;
        _minionPoints = 0;
         
    }

    public static void InitializeCoinUi()
    {
        _coinUI = GameObject.Find("Canvas/Coin").transform.GetChild(0);
    }

    public static void AddCoinPoint()
    {
        _coinPoints += _coinMultiplier;
        UpdateCoinAmount();
    }

    public static int GetCoins()
    {
        return _coinPoints;
    }

    private static void UpdateCoinAmount()
    {
        _coinUI.GetComponent<Text>().text = _coinPoints.ToString();
    }

    public static void AddMinionPoint()
    {
        _minionPoints++;
    }

    public static void UpdateCoinMultiplier(int multiplier)
    {
        _coinMultiplier = multiplier;
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
    }

    public static void DestroyShield()
    {
        _hasShield = false;
    }
}