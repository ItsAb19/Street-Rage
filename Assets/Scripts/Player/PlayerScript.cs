using System;
using System.Collections;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    private Vector2 movement;

    private bool canDash = true;
    private bool isDashing;
    public float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    Rigidbody2D rb;
    Transform playerTransform;
    Animator anim;
    BoxCollider2D boxCol;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        boxCol = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;
        }
        Movement();
        if (Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.Q) && movement.x > 0 && canDash == true)
        {
            anim.SetBool("ForwardDash", true);
            anim.SetBool("Walk", false);
            StartCoroutine(Dash());
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKeyDown(KeyCode.Q) && movement.x < 0 && canDash == true)
        {
            anim.SetBool("ForwardDash", true);
            anim.SetBool("Walk", false);
            StartCoroutine(Dash());
        }
    }

    void Movement()
    {
        Vector2 vel = rb.velocity;

        // Get player input for horizontal and vertical movement
        float moveX = Input.GetAxisRaw("Horizontal");  // Left/Right arrow keys or A/D
        float moveY = Input.GetAxisRaw("Vertical");    // Up/Down arrow keys or W/S

        movement = new Vector2(moveX, moveY).normalized;

        if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector3(-4, 4, 0);
            anim.SetBool("Walk", true);
            anim.SetBool("Idle", false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector3(4, 4, 0);
            anim.SetBool("Walk", true);
            anim.SetBool("Idle", false);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            transform.localScale = new Vector3(-4, 4, 0);
            anim.SetBool("Walk", false);
            anim.SetBool("Idle", true);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            transform.localScale = new Vector3(4, 4, 0);
            anim.SetBool("Walk", false);
            anim.SetBool("Idle", true);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector3(-4, 4, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.localScale = new Vector3(4, 4, 0);
        }
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            boxCol.enabled = true;
            anim.SetBool("Punch", true);
        }
        rb.velocity = vel;
    }
    void StopPunch()
    {
        boxCol.enabled = false;
        anim.SetBool("Punch", false);
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;

        // Store original values to restore later
        float originalDrag = rb.drag;
        float originalGravity = rb.gravityScale;

        // Temporarily modify physics for a clean dash
        rb.drag = 0f;
        rb.gravityScale = 0f;

        // Set dash velocity
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);

        // Prevent other movement updates from interfering
        yield return new WaitForSeconds(dashingTime);

        // End dash and restore values
        isDashing = false;
        rb.drag = originalDrag;
        rb.gravityScale = originalGravity;

        // Cooldown before next dash
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    void Idle()
    {
        anim.SetBool("Idle", true);
        anim.SetBool("ForwardDash", false);
    }
    void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        // Apply movement to the Rigidbody2D
        rb.velocity = movement * speed;
    }
}
