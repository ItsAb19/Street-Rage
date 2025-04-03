using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    GameObject enemy;
    public bool inRange;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inRange = false;
    }

    void DamageEnemy()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            inRange = true;
            enemy = collision.gameObject;
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
