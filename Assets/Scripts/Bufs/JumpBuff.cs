using UnityEngine;

public class JumpBuff : MonoBehaviour
{
    public PlayerMovement movement;
    public float buffDuration = 1;
    public float jumpMultiplier = 1f;

    private bool _isTriggered;

    private void Start()
    {
        movement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (_isTriggered)
        {
            buffDuration -= Time.deltaTime;
            if (buffDuration <= 0)
            {
                JumpDecrease();
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !_isTriggered)
        {
            WowPopup.Create(collision.transform, Resources.Load("WowPopup"), " jump");
            GameManager.PlayCollection();
            JumpIncrease();
            _isTriggered = true;
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void JumpIncrease()
    {
        movement.JumpMultiplier(jumpMultiplier);
    }

    private void JumpDecrease()
    {
        movement.JumpMultiplier(1 / jumpMultiplier);
    }
}