using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [Header("Lives")]
    public int maxLives = 3;
    private int currentLives;

    private Vector3 startingPosition;
    private Rigidbody2D rb;

    [Header("Game Over")]
    public GameOverUI gameOverUI;

    private bool dead = false;

    public int CurrentLives => currentLives;

    private void Start()
    {
        startingPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();

        currentLives = maxLives;
    }

    public void Die()
    {
        if (dead)
            return;

        currentLives--;

        Debug.Log("Lives left: " + currentLives);

        if (currentLives <= 0)
        {
            dead = true;

            Debug.Log("GAME OVER");

            if (gameOverUI != null)
            {
                gameOverUI.ShowGameOver();
            }

            return;
        }

        Respawn();
    }

    private void Respawn()
    {
        Vector3 respawnPosition;

        if (CheckpointManager.Instance != null)
        {
            respawnPosition =
                CheckpointManager.Instance.GetCheckpoint(startingPosition);
        }
        else
        {
            respawnPosition = startingPosition;
        }

        transform.position = respawnPosition;

        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
    }
}