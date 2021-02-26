using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpBuff : MonoBehaviour
{
    public PlayerMovement movement;
    public float speedUpDuration = 1;
    public float speedUpMultiplier = 2;

    private bool _isTriggered;

    private void Update()
    {
        if (_isTriggered)
        {
            speedUpDuration -= Time.deltaTime;
            if (speedUpDuration <= 0)
            {
                SpeedDownPlayer();
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !_isTriggered)
        {
            SpeedUpPlayer();
            _isTriggered = true;
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void SpeedUpPlayer()
    {
        movement.SpeedUpPlayer(speedUpMultiplier);
    }

    private void SpeedDownPlayer()
    {
        movement.SpeedUpPlayer(1 / speedUpMultiplier);
    }
}