using TMPro;
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
        if (GameManager.UpdateHighScore())
        {
            GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>().Play("win");
        }
        else
        {
            GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>().Play("lose");
        }

        _coinPoints = GameManager.GetCoins();
        score.GetComponent<TextMeshProUGUI>().text = _coinPoints.ToString();
        highscore.GetComponent<TextMeshProUGUI>().text = GameManager.GetHighScore().ToString();
    }
}