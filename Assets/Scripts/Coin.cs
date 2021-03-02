using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            WowPopup.Create(collision.transform, Resources.Load("WowPopup"), " coin");
            GameManager.AddCoinPoint();
            Destroy(gameObject);
        }
    }
}