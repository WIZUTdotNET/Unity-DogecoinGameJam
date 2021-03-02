using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private bool _isActive;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !_isActive)
        {
            _isActive = true;
            if (GameManager.IsShielded())
            {
                GameManager.DestroyShield();
            }
            else
            {
                GameManager.GameEnd();
            }
        }
    }
}