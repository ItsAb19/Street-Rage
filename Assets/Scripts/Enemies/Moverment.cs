using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyChase : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;
    public float stopDistance = 1f;
    public float chaseRange = 10f; // The maximum distance at which the enemy will start chasing the player

    // Health variables
    public int maxHealth = 100;
    private int currentHealth;

    // Stun variables (if you want a short stun after being hit)
    private bool isStunned = false;
    public float stunDuration = 0.5f;

    private Rigidbody2D rb;

    // Flag to indicate if enemy is colliding with the player (or barrier)
    private bool isCollidingWithPlayer = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (player != null && !isStunned)
        {
            float distance = Vector2.Distance(transform.position, player.position);

            // Check if the player is within chase range
            if (distance <= chaseRange)
            {
                // If far enough and not colliding, move towards the player
                if (distance > stopDistance && !isCollidingWithPlayer)
                {
                    Vector2 newPos = Vector2.MoveTowards(rb.position, player.position, speed * Time.deltaTime);
                    rb.MovePosition(newPos);
                }
                else
                {
                    // Stop movement when within stop distance or colliding with the player
                    rb.velocity = Vector2.zero;
                }

                // Flip the enemy's sprite to face the player
                Vector3 localScale = transform.localScale;
                localScale.x = (player.position.x > transform.position.x)
                    ? Mathf.Abs(localScale.x)
                    : -Mathf.Abs(localScale.x);
                transform.localScale = localScale;
            }
            else
            {
                // Player is out of chase range, so enemy stops moving.
                rb.velocity = Vector2.zero;
            }
        }
    }

    // When collision with the player begins, set the flag and zero out velocity.
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isCollidingWithPlayer = true;
            rb.velocity = Vector2.zero;
        }
    }

    // When collision with the player ends, reset the flag.
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isCollidingWithPlayer = false;
        }
    }

    // Called when the enemy takes damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Enemy takes " + damage + " damage. Health: " + currentHealth);
        if (currentHealth <= 0)
        {
            Debug.Log("Enemy health reached zero. Dying.");
            Die();
        }
        else
        {
            // Optional: briefly stun the enemy upon being hit
            StartCoroutine(Stun());
        }
    }

    private IEnumerator Stun()
    {
        isStunned = true;
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(stunDuration);
        isStunned = false;
    }

    void Die()
    {
        Debug.Log("Enemy died!");
        Destroy(gameObject);
    }
}
