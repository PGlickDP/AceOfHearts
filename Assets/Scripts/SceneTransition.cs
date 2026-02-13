using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    public CanvasGroup fadeCanvasGroup;
    public float fadeDuration = 1f;

    void Start()
    {
        // Fade in at start
        StartCoroutine(FadeIn());
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(FadeOutAndLoad(sceneName));
    }

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

    IEnumerator FadeOutAndLoad(string sceneName)
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