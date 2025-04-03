using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    PlayerHealth playerHealth;
    GameObject playerObj;

    private void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        playerHealth = playerObj.GetComponent<PlayerHealth>();
    }
    // Amount of health to restore instantly
    public float healthAmount = 40f;

    // Called when another collider enters the trigger collider attached to the collectible
    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            // Get the PlayerHealth component from the colliding object
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                // Increase player's health instantly
                playerHealth.currentHealth += healthAmount;

                // Clamp the health so it doesn't exceed 100
                if (playerHealth.currentHealth > 100f)
                {
                    playerHealth.currentHealth = 100f;
                }

                // Destroy the collectible after it's been used
                Destroy(gameObject);
            }
        }
    }
}
