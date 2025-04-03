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
            // Get the PlayerAttack component from the player object
            PlayerAttack playerAttack = collision.GetComponent<PlayerAttack>();
            if (playerAttack != null)
            {
                // Increase the player's attack power by the specified amount
                playerAttack.attackPower += attackIncrease;
                Debug.Log("Player's attack power increased by " + attackIncrease);

                // Start coroutine to remove the buff after a delay
                StartCoroutine(RemoveBuffAfterTime(playerAttack, attackIncrease, buffDuration));
            }

            // Destroy the power-up after it has been collected
            Destroy(gameObject);
        }
    }

    private IEnumerator RemoveBuffAfterTime(PlayerAttack playerAttack, float amount, float duration)
    {
        yield return new WaitForSeconds(duration);
        playerAttack.attackPower -= amount;
        Debug.Log("Player's attack power buff removed after " + duration + " seconds");
    }
}
