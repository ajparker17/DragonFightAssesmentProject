using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public HealthBar healthBar;
    public int currentHealth;


    void Start()
    {
        currentHealth = maxHealth;
    }
    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.UpdateHealth((float)currentHealth/(float)maxHealth);

        if(currentHealth <=0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

}
