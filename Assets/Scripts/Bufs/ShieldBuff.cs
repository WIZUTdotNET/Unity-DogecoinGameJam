using UnityEngine;

public class ShieldBuff : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            WowPopup.Create(collision.transform, Resources.Load("WowPopup"), " shield");
            GameManager.GiveShield();
            Destroy(gameObject);
        }
    }
}