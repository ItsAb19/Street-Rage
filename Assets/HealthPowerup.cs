using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    // Amount of health to restore instantly
    public float healthAmount = 40f;

    // Called when another collider enters the trigger collider attached to the collectible
    private void OnTriggerEnter(Collider other)
    {
        // Try to get the PlayerHealth component from the colliding object
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            // Increase player's health instantly
            playerHealth.currentHealth += healthAmount;

            // Clamp the health so it doesn't go over 100
            if (playerHealth.currentHealth > 100f)
            {
                playerHealth.currentHealth = 100f;
            }

            // Destroy the collectible object
            Destroy(gameObject);
        }
    }
}
