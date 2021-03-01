using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private Transform wowPopup;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.AddCoinPoint();
            WowPopup.Create(collision.transform, wowPopup);
            Destroy(gameObject);
        }
    }
}