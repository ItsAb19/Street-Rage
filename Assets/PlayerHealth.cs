using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{

    public float maxHealth;
    public Image healthBar;
    public float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(currentHealth / maxHealth, 0, 1);
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
  
}
