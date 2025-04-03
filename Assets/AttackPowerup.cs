using UnityEngine;
using System.Collections;

public class AttackPowerup : MonoBehaviour
{
    PlayerAttack playerAttack;
    GameObject playerObj;

    private void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        playerAttack = playerObj.GetComponent<PlayerAttack>();
    }

    public float attackIncrease = 50f;
    public float buffDuration = 10f;

    // Called when another collider enters the trigger collider attached to the power-up
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object is tagged "Player"
        if (collision.CompareTag("Player"))
        {
            // Get the PlayerAttack component from the colliding player object
            PlayerAttack playerAttack = collision.GetComponent<PlayerAttack>();
            if (playerAttack != null)
            {
                // Store the original attack power
                float originalAttackPower = playerAttack.attackPower;

                // Increase the player's attack power by the specified amount
                playerAttack.attackPower += attackIncrease;
                Debug.Log("Player's attack power increased by " + attackIncrease);

                // Start the coroutine on the player's MonoBehaviour so it continues even after this power-up is destroyed
                playerAttack.StartCoroutine(RemoveBuffAfterTime(playerAttack, originalAttackPower, buffDuration));
            }

            // Destroy the power-up after it has been collected
            Destroy(gameObject);
        }
    }

    private IEnumerator RemoveBuffAfterTime(PlayerAttack playerAttack, float originalAttackPower, float duration)
    {
        yield return new WaitForSeconds(duration);
        // Reset the player's attack power back to the original value
        playerAttack.attackPower = originalAttackPower;
        Debug.Log("Player's attack power reset to original value after " + duration + " seconds");
    }
}
