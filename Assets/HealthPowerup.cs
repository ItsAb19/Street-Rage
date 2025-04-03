using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    PlayerHealth playerHealth;
    public GameObject playerObj;

    private void Start()
    {
        playerHealth = playerObj.GetComponent<PlayerHealth>();
    }
    // Amount of health to restore instantly
    public float healthAmount = 40f;

    // Called when another collider enters the trigger collider attached to the collectible
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("working");
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
