using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vel = rb.velocity;

        if (Input.GetKeyDown(KeyCode.W))
        {
            vel.y = speed;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            vel.y = 0;
        }

        rb.velocity = vel;
    }
}
