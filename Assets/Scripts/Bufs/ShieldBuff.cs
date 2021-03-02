using UnityEngine;

public class ShieldBuff : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.GiveShield();
            Destroy(gameObject);
        }
    }
}