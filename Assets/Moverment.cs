using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    // Reference to the player's Transform.
    public Transform player;
    // Speed at which the enemy moves.
    public float speed = 3f;

    void Update()
    {
        if (player != null)
        {
            // Calculate target position while maintaining the enemy's current y-position.
            Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
            // Move the enemy towards the target position.
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }
}
