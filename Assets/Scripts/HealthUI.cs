using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public PlayerHealth playerHealth; // Drag your Player here
    public Image faceImage;           // The UI Image that displays the face

    [Header("Face Sprites by Health")]
    public Sprite[] faceSprites;      // Array of sprites from 0 HP to max HP

    void Update()
    {
        if (playerHealth == null || faceImage == null || faceSprites.Length == 0)
            return;

        int hp = playerHealth.GetCurrentHealth();

        // Clamp hp to valid array index
        hp = Mathf.Clamp(hp, 0, faceSprites.Length - 1);

        faceImage.sprite = faceSprites[hp];
    }
}