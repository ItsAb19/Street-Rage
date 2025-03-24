using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    float MaxHealth = 100;
    public float currentHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            Debug.Log("Dead");
        }
    }
}
