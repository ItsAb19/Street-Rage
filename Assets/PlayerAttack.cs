using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    GameObject enemy;
    EnemyHealth enemyHealth;
    public bool inRange;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inRange = false;
    }

    void DamageEnemy()
    {
        if(inRange == true)
        {
            enemyHealth.currentHealth -= 25;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            inRange = true;
            enemy = collision.gameObject;
            enemyHealth = enemy.GetComponent<EnemyHealth>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            inRange = false;
        }
    }
}
