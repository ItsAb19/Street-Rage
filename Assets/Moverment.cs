using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyChase : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;
    public float stopDistance = 1f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (player != null)
        {
            float distance = Vector2.Distance(transform.position, player.position);

            if (distance > stopDistance)
            {
                // Use Rigidbody2D.MovePosition to avoid jittering
                Vector2 direction = (player.position - transform.position).normalized;
                rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
            }

            // Flip the enemy's x scale based on the player's position
            Vector3 localScale = transform.localScale;
            localScale.x = (player.position.x > transform.position.x)
                ? Mathf.Abs(localScale.x)  // Face right
                : -Mathf.Abs(localScale.x); // Face left
            transform.localScale = localScale;
        }
    }
}
