using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    public float baseMaxHealth = 100;
    public bool invincible = false;

    float currentHealth;

    void Start()
    {
        currentHealth = baseMaxHealth;
    }

    /// <summary>
    /// Lowers the overall health of the character. Will return false if no damage was removed
    /// </summary>
    /// <param name="damageTaken"></param>
    /// <returns></returns>
    public bool takeDamage(float damageTaken) 
    {
        if (invincible) return false;
        currentHealth = Mathf.MoveTowards(currentHealth, 0, damageTaken);
        return true;
    }

    public void heal(float healAmount)
    {
        currentHealth = Mathf.MoveTowards(currentHealth, baseMaxHealth, healAmount);
    }

    public float getCurrentHealth()
    {
        return currentHealth;
    }


}
