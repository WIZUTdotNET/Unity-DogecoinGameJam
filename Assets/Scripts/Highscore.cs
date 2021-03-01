using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
    public Transform score;
    public Transform highscore;

    private int _highScore=0;
    private int _coinPoints;
    private Transform _coinUI;

    public void Awake()
    {
        _coinPoints = GameManager.GetCoins();
        Debug.Log(_coinPoints);
        score.GetComponent<Text>().text = _coinPoints.ToString();

        if(_coinPoints>_highScore)
        {
            _highScore = _coinPoints;
            highscore.GetComponent<Text>().text = _highScore.ToString();
        }
    }
    


}
