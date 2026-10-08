using UnityEngine;

public class Exit : MonoBehaviour
{
    public Door requiredDoor;

    private bool completed = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (completed) return;

        if (!other.CompareTag("Player"))
            return;

        // If this exit requires the door to be open
        if (requiredDoor != null && !requiredDoor.IsOpen)
            return;

        completed = true;

        Debug.Log("EXIT TRIGGERED - Loading next level");

        LevelManager.Instance.LoadNextLevel();
    }
}