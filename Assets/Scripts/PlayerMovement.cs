using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpVelocity = 10f;
    public float speed = 20f;
    private bool _grounded;
    private LayerMask _groundLayerMask;

    private Rigidbody2D _playerRb;

    private void Start()
    {
        _playerRb = transform.GetComponent<Rigidbody2D>();
        _groundLayerMask = LayerMask.NameToLayer("Ground");
        GameManager.InitializeCoinUi();
    }

    private void Update()
    {
        _playerRb.velocity = new Vector2(speed, _playerRb.velocity.y);
        if (_grounded && Input.GetButtonDown("Jump")) _playerRb.velocity = Vector2.up * jumpVelocity;

        if (transform.position.y <= -20) GameManager.GameEnd();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == _groundLayerMask) _grounded = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == _groundLayerMask) _grounded = false;
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