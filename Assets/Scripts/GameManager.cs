using UnityEngine;
using UnityEngine.SceneManagement; // Needed for loading scenes

public class GameManager : MonoBehaviour
{
    [Header("UI References")]
    public GameObject mainMenuCanvas; // Drag MainMenuCanvas here

    // Call this from PlayButton
    public void PlayGame()
    {
        Debug.Log("Play button pressed");
        // Load the main gameplay scene
        SceneManager.LoadScene("MainScene"); // Replace "MainScene" with your gameplay scene name
    }

    // Call this from CreditsButton
    public void ShowCredits()
    {
        Debug.Log("Credits button pressed");
        // For simplicity, just log or open another UI panel
        // You can also load a Credits scene if you have one
        // SceneManager.LoadScene("CreditsScene");
    }

    // Optional: Exit game
    public void QuitGame()
    {
        Debug.Log("Quit button pressed");
        Application.Quit();
    }
}