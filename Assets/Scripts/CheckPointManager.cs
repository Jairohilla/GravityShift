using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager Instance;

    private Vector3 checkpointPosition;
    private bool checkpointActive;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetCheckpoint(Vector3 position)
    {
        checkpointPosition = position;
        checkpointActive = true;
    }

    public Vector3 GetCheckpoint(Vector3 defaultPosition)
    {
        if (checkpointActive)
            return checkpointPosition;

        return defaultPosition;
    }
}