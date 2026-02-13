using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject mainMenuPanel;
    public GameObject creditsPanel;
    public GameObject gameOverPanel; // Reference to GameOverPanel

    [Header("Fade Settings")]
    public float fadeDuration = 1f; // seconds

    private CanvasGroup gameOverCanvasGroup;

    void Awake()
    {
        // Setup GameOver CanvasGroup
        if (gameOverPanel != null)
        {
            gameOverCanvasGroup = gameOverPanel.GetComponent<CanvasGroup>();
            if (gameOverCanvasGroup == null)
                gameOverCanvasGroup = gameOverPanel.AddComponent<CanvasGroup>();

            gameOverCanvasGroup.alpha = 0f;
            gameOverPanel.SetActive(false); // hide at start
        }
    }

    // -------------------------
    // Main Menu Functions
    // -------------------------
    public void PlayGame()
    {
        Debug.Log("Play button pressed");
        SceneManager.LoadScene("MainScene"); // Replace with your gameplay scene
    }

    public void ShowCredits()
    {
        if (creditsPanel != null && mainMenuPanel != null)
        {
            creditsPanel.SetActive(true);
            mainMenuPanel.SetActive(false);
        }
    }

    public void CloseCredits()
    {
        if (creditsPanel != null && mainMenuPanel != null)
        {
            creditsPanel.SetActive(false);
            mainMenuPanel.SetActive(true);
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quit button pressed");
        Application.Quit();
    }

    // -------------------------
    // Game Over Functions
    // -------------------------
    public void ShowGameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            StartCoroutine(FadeInGameOver());
        }
    }

    private IEnumerator FadeInGameOver()
    {
        float timer = 0f;

        if (gameOverCanvasGroup == null)
            yield break;

        gameOverCanvasGroup.alpha = 0f;
        gameOverCanvasGroup.interactable = false;
        gameOverCanvasGroup.blocksRaycasts = false;

        while (timer < fadeDuration)
        {
            timer += Time.unscaledDeltaTime; // works even if Time.timeScale = 0
            gameOverCanvasGroup.alpha = Mathf.Clamp01(timer / fadeDuration);
            yield return null;
        }

        gameOverCanvasGroup.alpha = 1f;
        gameOverCanvasGroup.interactable = true;
        gameOverCanvasGroup.blocksRaycasts = true;
    }

    public void RetryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene"); // Replace with your main menu scene
    }
}