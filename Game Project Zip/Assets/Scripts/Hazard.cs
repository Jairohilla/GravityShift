using UnityEngine;

public class Hazard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        PlayerDeath playerDeath = other.GetComponent<PlayerDeath>();

        if (playerDeath != null)
        {
            playerDeath.Die();
        }
        else
        {
            Debug.LogError("PlayerDeath component is missing from the Player!");
        }
    }
}