using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    // Reference to the player's Transform.
    public Transform player;
    // Speed at which the enemy moves.
    public float speed = 3f;
    // The distance at which the enemy will stop chasing.
    public float stopDistance = 1f;

    void Update()
    {
        if (player != null)
        {
            // Calculate the distance between the enemy and the player.
            float distance = Vector3.Distance(transform.position, player.position);

            // If the enemy is farther than the stop distance, keep moving toward the player.
            if (distance > stopDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }

            // Flip the enemy's x scale based on the player's position relative to the enemy.
            Vector3 localScale = transform.localScale;
            if (player.position.x > transform.position.x)
            {
                localScale.x = Mathf.Abs(localScale.x); // Face right
            }
            else
            {
                localScale.x = -Mathf.Abs(localScale.x); // Face left
            }
            transform.localScale = localScale;
        }
    }
}
