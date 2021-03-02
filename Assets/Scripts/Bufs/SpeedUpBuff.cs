using UnityEngine;

public class SpeedUpBuff : MonoBehaviour
{
    public PlayerMovement movement;
    public float speedUpDuration = 1;
    public float speedUpMultiplier = 2;

    private bool _isTriggered;

    private void Start()
    {
        movement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }

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
            WowPopup.Create(collision.transform, Resources.Load("WowPopup"), " speed");
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