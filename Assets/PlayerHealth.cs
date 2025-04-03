using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{

    public GameObject greenHealthbar;
    private Image greenHealthbarImage;

    float MaxHealth = 100;
    public float currentHealth;
    void Start()
    {
        currentHealth = MaxHealth;
        greenHealthbarImage = greenHealthbar.GetComponent<Image>();
    }

    void OnTriggerEnter2D(Collider2D enemyHitbox)
    {
        if (enemyHitbox.tag == "enemyHitbox")
        {
            greenHealthbarImage.fillAmount -= 0.2f;
        }
    }

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
