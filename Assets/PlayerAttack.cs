using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject attackCrate;
    public GameObject hpCrate;

    GameObject enemy;
    GameObject destroyAttackCrate;
    GameObject destroyHpCrate;
    EnemyHealth enemyHealth;
    public bool inRange;
    public float attackPower;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inRange = false;
        attackPower = 25;
    }

    void DamageEnemy()
    {
        if(inRange == true)
        {
            enemyHealth.currentHealth -= attackPower;
        }
    }
    void DestroyBox()
    {
        if (inRange == true && attackCrate!= null)
        {
            Destroy(destroyAttackCrate);
        }
        if (inRange == true && hpCrate != null)
        {
            Destroy(destroyHpCrate);
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
        if (collision.CompareTag("Crate"))
        {
            inRange = true;
            destroyAttackCrate = collision.gameObject;
        }
        if (collision.CompareTag("hpCrate"))
        {
            inRange = true;
            destroyHpCrate = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            inRange = false;
        }
        if (collision.CompareTag("Crate"))
        {
            inRange = false;
        }
        if (collision.CompareTag("hpCrate"))
        {
            inRange = false;
        }
    }
}
