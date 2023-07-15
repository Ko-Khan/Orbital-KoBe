using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    [SerializeField] private int healAmount;
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Healthbar bar = GameObject.FindWithTag("UI").GetComponent<Healthbar>();
            Health playerHealth = other.gameObject.GetComponent<Health>();
            playerHealth.currentHealth += healAmount;
            if (playerHealth.currentHealth > playerHealth.maxHealth)
            {
                playerHealth.currentHealth = playerHealth.maxHealth;
            }
            bar.setHealth(playerHealth.currentHealth);

            Destroy(gameObject);
        }
    }
}
