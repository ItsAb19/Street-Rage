using UnityEngine;

public class CrateHealth : MonoBehaviour
{
    public GameObject scoreObj;
    ScoreScript scoreScr;

    public float MaxHealth = 50;
    public float currentHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreScr = scoreObj.GetComponent<ScoreScript>();
        currentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            scoreScr.score += 100;
            Destroy(this.gameObject);
        }
    }
}
