using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    BoxCollider2D boxCol;
    Animator anim;
    PlayerHealth playerHealth;
    public GameObject playerObj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boxCol = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        playerHealth = playerObj.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DamagePlayer()
    {
        playerHealth.currentHealth -= 10;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("Attack", true);
            anim.SetBool("Walk", false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("Attack", false);
            anim.SetBool("Walk", true);
        }
    }
}
