using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject mainMenuPanel;
    public GameObject creditsPanel;
    public GameObject gameOverPanel; // Add reference to GameOverPanel

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
        }
    }

    public void RetryGame()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene"); // Replace with your main menu scene
    }
}