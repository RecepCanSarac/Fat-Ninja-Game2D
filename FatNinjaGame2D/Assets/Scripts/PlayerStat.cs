using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealtBar healthbar;
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Time.timeScale = 0.0f;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthbar.SetHealth(currentHealth);
    }
}
