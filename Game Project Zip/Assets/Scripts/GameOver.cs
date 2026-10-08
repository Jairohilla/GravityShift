using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public CanvasGroup gameOverCanvasGroup;
    public float fadeDuration = 1.5f;

    private bool gameOverShown = false;

    public void ShowGameOver()
    {
        if (gameOverShown)
            return;

        gameOverShown = true;

        gameOverCanvasGroup.gameObject.SetActive(true);

        StartCoroutine(FadeInGameOver());
    }

    private System.Collections.IEnumerator FadeInGameOver()
    {
        float timer = 0f;

        gameOverCanvasGroup.alpha = 0f;
        gameOverCanvasGroup.interactable = false;
        gameOverCanvasGroup.blocksRaycasts = false;

        while (timer < fadeDuration)
        {
            timer += Time.unscaledDeltaTime;

            gameOverCanvasGroup.alpha =
                Mathf.Clamp01(timer / fadeDuration);

            yield return null;
        }

        gameOverCanvasGroup.alpha = 1f;

        // Enable UI interaction
        gameOverCanvasGroup.interactable = true;
        gameOverCanvasGroup.blocksRaycasts = true;

        // Pause game
        Time.timeScale = 0f;
    }

    public void RestartLevel()
    {
        // Very important because the game is paused
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}