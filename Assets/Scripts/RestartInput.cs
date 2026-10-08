using UnityEngine;

public class RestartInput : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            LevelManager.Instance.RestartLevel();
        }
    }
}