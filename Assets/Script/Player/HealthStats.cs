using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HealthStats 
{
    //Fields
    private float currentMaxHealth;
    private float currentHealth;

    //Properties
    public float Health
    {
        get { return currentHealth; }
        set { currentHealth = value; }
    }

    public float MaxHealth
    {
        get { return currentMaxHealth; }
        set { currentMaxHealth = value; }
    }

    //Constructor
    public HealthStats(float health, float maxHealth)
    {
        currentHealth = health;
        currentMaxHealth = maxHealth;
    }

    //Methods
    public void DamageUnit(float dmgAmount)
    {
        if (currentHealth > 0)
        {
            currentHealth -= dmgAmount;
        }
    }

    public void HealUnit(float healAmount)
    {
        if (currentHealth < currentMaxHealth)
        {
            currentHealth += healAmount;
        }
        if (currentHealth > currentMaxHealth)
        {
            currentHealth = currentMaxHealth;
        }
    }
}
