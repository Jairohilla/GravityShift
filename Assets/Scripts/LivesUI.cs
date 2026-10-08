using UnityEngine;
using TMPro;

public class LivesUI : MonoBehaviour
{
    public TMP_Text livesText;
    public PlayerDeath playerDeath;

    private void Update()
    {
        if (playerDeath != null)
        {
            livesText.text =
                "" + playerDeath.CurrentLives;
        }
    }
}