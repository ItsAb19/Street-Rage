using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    private Vector2 movement;

    Rigidbody2D rb;
    Transform playerTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vel = rb.velocity;

        // Get player input for horizontal and vertical movement
        float moveX = Input.GetAxisRaw("Horizontal");  // Left/Right arrow keys or A/D
        float moveY = Input.GetAxisRaw("Vertical");    // Up/Down arrow keys or W/S

        movement = new Vector2(moveX, moveY).normalized;

        if(Input.GetKeyDown(KeyCode.A))
        {
            transform.localScale = new Vector3(-4, 4, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.localScale = new Vector3(4, 4, 0);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector3(-4, 4, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.localScale = new Vector3(4, 4, 0);
        }

        rb.velocity = vel;
    }

    void FixedUpdate()
    {
        // Apply movement to the Rigidbody2D
        rb.velocity = movement * speed;
    }
}
