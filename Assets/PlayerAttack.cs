using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public bool inRange;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inRange = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            inRange = true;
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
