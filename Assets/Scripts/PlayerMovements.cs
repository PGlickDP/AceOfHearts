using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody2D component attached to the GameObject
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame (for user input)
    void Update()
    {
        // Get raw input for horizontal and vertical axes (WASD/Arrow Keys)
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Normalize the movement vector to ensure consistent speed in all directions (especially diagonals)
        movement.Normalize();
    }

    // FixedUpdate is called at a fixed interval and is independent of frame rate (for physics calculations)
    void FixedUpdate()
    {
        // Apply movement to the Rigidbody2D's velocity
        rb.linearVelocity = movement * moveSpeed;
    }
}
