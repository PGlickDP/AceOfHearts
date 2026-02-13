using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 6;
    private int currentHealth;

    [Header("Damage Feedback")]
    public float damageCooldown = 0.5f;      // Time between allowed hits
    public float flashDuration = 0.1f;       // Flash time on hit
    public Color flashColor = Color.red;

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

    private System.Collections.IEnumerator DamageFlash()
    {
        spriteRenderer.color = flashColor;
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = originalColor;
    }

    void Die()
    {
        Debug.Log("Player Died");
        gameObject.SetActive(false);
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}