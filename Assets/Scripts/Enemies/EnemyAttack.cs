using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    Animator anim;
    BoxCollider2D boxCol;
    public GameObject playerObject;
    PlayerHealth playerHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boxCol = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        playerHealth = playerObject.GetComponent<PlayerHealth>();
    }

    void DamagePlayer()
    {
        playerHealth.currentHealth -= 10;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //attack animation
            anim.SetBool("Attack", true);
            anim.SetBool("Idle", false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //attack animation
            anim.SetBool("Attack", false);
            anim.SetBool("Idle", true);
        }
    }
}
