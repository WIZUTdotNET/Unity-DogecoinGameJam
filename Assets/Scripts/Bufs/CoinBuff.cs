using UnityEngine;

public class CoinBuff : MonoBehaviour
{
    public float buffDuration = 1;
    public int coinMultiplier = 2;

    private bool _isTriggered;

    private void Update()
    {
        if (_isTriggered)
        {
            buffDuration -= Time.deltaTime;
            if (buffDuration <= 0)
            {
                CoinDecrease();
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !_isTriggered)
        {
            WowPopup.Create(collision.transform, Resources.Load("WowPopup"), " more coin");
            CoinIncrease();
            _isTriggered = true;
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void CoinIncrease()
    {
        GameManager.UpdateCoinMultiplier(coinMultiplier);
    }

    private void CoinDecrease()
    {
        GameManager.RestoreCoinMultiplier();
    }
}