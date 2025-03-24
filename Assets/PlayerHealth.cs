using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    float maxHealth = 100;
    public float currentHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            //game over
            Debug.Log("Player is dead");
        }
    }
}
