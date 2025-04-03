using UnityEngine;

public class AttackPowerup : MonoBehaviour
{
    PlayerAttack playerAttack;
    GameObject playerObj;

    private void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        playerAttack = playerObj.GetComponent<PlayerAttack>();
    }

    private void OnTriggerEnter(Collider other)
    {
      
    }
}
