using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.AddCoinPoint();
            WowPopup.Create(collision.transform, Resources.Load("WowPopup"), " coin");
            Destroy(gameObject);
        }
    }
}