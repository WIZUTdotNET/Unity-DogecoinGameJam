using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
    public Transform score;
    public Transform highscore;

    private int _coinPoints;
    private Transform _coinUI;

    public void Awake()
    {
        _coinPoints = GameManager.GetCoins();
        score.GetComponent<Text>().text = _coinPoints.ToString();
        highscore.GetComponent<Text>().text = GameManager.GetHighScore().ToString();
    }
}