using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject mainMenuPanel;
    public GameObject creditsPanel;
    public GameObject gameOverPanel;

    [Header("Fade Settings")]
    public CanvasGroup fadeCanvasGroup;   // Assign FadePanel CanvasGroup
    public float fadeDuration = 1f;

    void Start()
    {
        // Fade in when scene starts
        if (fadeCanvasGroup != null)
        {
            StartCoroutine(FadeIn());
        }
    }

    // -------------------------
    // Main Menu Functions
    // -------------------------

    public void PlayGame()
    {
        StartCoroutine(FadeAndLoad("EnemyTest"));
    }

    public void ShowCredits()
    {
        creditsPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }

    public void CloseCredits()
    {
        creditsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void QuitGame()
    {
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
        }
    }

    public void RetryGame()
    {
        StartCoroutine(FadeAndLoad(SceneManager.GetActiveScene().name));
    }

    public void ReturnToMainMenu()
    {
        StartCoroutine(FadeAndLoad("Main Menu"));
    }

    // -------------------------
    // Fade Logic
    // -------------------------

    IEnumerator FadeIn()
    {
        float timer = 0f;
        fadeCanvasGroup.alpha = 1f;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            fadeCanvasGroup.alpha = 1f - (timer / fadeDuration);
            yield return null;
        }

        fadeCanvasGroup.alpha = 0f;
    }

    IEnumerator FadeAndLoad(string sceneName)
    {
        float timer = 0f;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            fadeCanvasGroup.alpha = timer / fadeDuration;
            yield return null;
        }

        fadeCanvasGroup.alpha = 1f;

        SceneManager.LoadScene(sceneName);
    }
}