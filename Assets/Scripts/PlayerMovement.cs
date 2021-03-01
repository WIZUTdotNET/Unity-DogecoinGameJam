using System;
using System.Net.NetworkInformation;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const int VoidLevel = -20;
    public float jumpVelocity = 10f;
    public float speed = 20f;

    private float _speedIncrement = .08f;
    private bool _grounded;
    private LayerMask _groundLayerMask;
    private Rigidbody2D _playerRb;

    private EventHandler<TimeTickSystem.OnTickEvents> _tickSystemDelegate;

    private void Start()
    {
        _tickSystemDelegate = delegate(object sender, TimeTickSystem.OnTickEvents events)
        {
            speed += _speedIncrement;
        };
        TimeTickSystem.OnTick += _tickSystemDelegate;
        _playerRb = transform.GetComponent<Rigidbody2D>();
        _groundLayerMask = LayerMask.NameToLayer("Ground");
        GameManager.InitializeCoinUi();
    }

    private void Update()
    {
        _playerRb.velocity = new Vector2(speed, _playerRb.velocity.y);
        if (_grounded && Input.GetButtonDown("Jump")) _playerRb.velocity = Vector2.up * jumpVelocity;

        KillWhenUngerGround();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == _groundLayerMask) _grounded = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == _groundLayerMask) _grounded = false;
    }

    private void KillWhenUngerGround()
    {
        if (transform.position.y <= VoidLevel) GameManager.GameEnd();
    }

    public void SpeedUpPlayer(float multiplier)
    {
        speed *= multiplier;
    }

    public void JumpMultiplier(float multiplier)
    {
        jumpVelocity *= multiplier;
    }
}