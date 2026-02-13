using UnityEngine;
using UnityEngine.UI; // <-- Needed for Image

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 6;
    public int currentHealth;

    [Header("Damage Feedback")]
    public float damageCooldown = 0.5f;      // Time between allowed hits
    public float flashDuration = 0.1f;       // Flash time on hit
    public Color flashColor = Color.red;

    [Header("UI Feedback")]
    public HealthUI healthUI; // drag your HealthUI component here
    public Color uiFlashColor = Color.red;
    public float uiFlashDuration = 0.1f;

    private float damageCooldownTimer = 0f;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    private PlayerMovement playerMovement;

    void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (damageCooldownTimer > 0f)
        {
            damageCooldownTimer -= Time.deltaTime;
        }
    }

    public void TakeDamage(int amount)
    {
        // Ignore damage if dashing (invincible) or in cooldown
        if ((playerMovement != null && playerMovement.IsInvincible()) || damageCooldownTimer > 0f)
            return;

        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        // Trigger flash and start cooldown
        StartCoroutine(DamageFlash());

        damageCooldownTimer = damageCooldown;

        Debug.Log("Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void AddHealth(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log("Health Added! Current Health: " + currentHealth);
    }

    private System.Collections.IEnumerator DamageFlash()
    {
        // Flash player sprite
        spriteRenderer.color = flashColor;

        // Flash UI face if assigned
        if (healthUI != null && healthUI.faceImage != null)
        {
            Image faceImg = healthUI.faceImage;
            Color originalFaceColor = faceImg.color;
            faceImg.color = uiFlashColor;

            yield return new WaitForSeconds(flashDuration);

            faceImg.color = originalFaceColor;
        }
        else
        {
            yield return new WaitForSeconds(flashDuration);
        }

        // Reset player sprite
        spriteRenderer.color = originalColor;
    }

    void Die()
{
    Debug.Log("Player Died");
    gameObject.SetActive(false);

    // Show Game Over screen
    GameManager gm = FindObjectOfType<GameManager>();
    if (gm != null)
    {
        gm.ShowGameOver();
    }
}

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}