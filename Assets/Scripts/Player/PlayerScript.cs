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
        
        //move up
        if (Input.GetKeyDown(KeyCode.W))
        {
            vel.y = speed;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            vel.y = 0;
        }
        //move down
        if (Input.GetKeyDown(KeyCode.S))
        {
            vel.y = -speed;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            vel.y = 0;
        }
        //move left 
        if (Input.GetKeyDown(KeyCode.A))
        {
            vel.x = -speed;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            vel.x = 0;
        }
        //move right
        if (Input.GetKeyDown(KeyCode.D))
        {
            vel.x = speed;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            vel.x = 0;
        }



        rb.velocity = vel;
    }
}
