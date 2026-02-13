using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;

    [Header("Dash")]
    public float dashDistance = 3f;
    public float dashDuration = 0.15f;
    public float dashCooldown = 1f;

    [Header("Invincibility")]
    public float invincibilityTime = 0.2f;

    [Header("Flash Effect")]
    public float flashInterval = 0.1f;

    private Rigidbody2D rb;
    private Collider2D col;
    private SpriteRenderer spriteRenderer;

    private Vector2 movement;

    private bool isDashing = false;
    private bool isInvincible = false;

    private float dashCooldownTimer;
    private float dashTimer;
    private float invincibleTimer;
    private float flashTimer;

    private Vector2 dashDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Movement input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;

        // Dash input
        if (Input.GetKeyDown(KeyCode.Space) && dashCooldownTimer <= 0f && movement != Vector2.zero)
        {
            StartDash();
        }

        // Cooldown timer
        if (dashCooldownTimer > 0f)
            dashCooldownTimer -= Time.deltaTime;

        // Invincibility + Flash logic
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            flashTimer -= Time.deltaTime;

            if (flashTimer <= 0f)
            {
                ToggleFlash();
                flashTimer = flashInterval;
            }

            if (invincibleTimer <= 0f)
            {
                isInvincible = false;
                spriteRenderer.color = Color.white;
            }
        }
    }

    void FixedUpdate()
    {
        if (isDashing)
        {
            dashTimer -= Time.fixedDeltaTime;

            if (dashTimer <= 0f)
            {
                isDashing = false;
                return;
            }
        }
        else
        {
            rb.linearVelocity = movement * moveSpeed;
        }
    }

    void StartDash()
    {
        isDashing = true;
        dashTimer = dashDuration;
        dashCooldownTimer = dashCooldown;

        isInvincible = true;
        invincibleTimer = invincibilityTime;
        flashTimer = flashInterval;

        dashDirection = movement;

        PerformDash();
    }

    void PerformDash()
    {
        RaycastHit2D[] hits = new RaycastHit2D[5];

        int hitCount = rb.Cast(dashDirection, hits, dashDistance);

        float finalDistance = dashDistance;

        if (hitCount > 0)
        {
            finalDistance = hits[0].distance - 0.05f;
        }

        Vector2 newPosition = rb.position + dashDirection * finalDistance;
        rb.MovePosition(newPosition);
    }

    void ToggleFlash()
    {
        if (spriteRenderer.color.a == 1f)
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, 0.3f);
        }
        else
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
        }
    }

    public bool IsInvincible()
    {
        return isInvincible;
    }
}