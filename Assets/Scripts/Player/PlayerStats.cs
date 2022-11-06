using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats 
{
    //Fields
    float currentHealth;
    float currentMinHealth;
    float currentMaxHealth;

    float currentExp;
    float currentMaxExp;
    int currentLvl;

    float currentEnergy;
    float currentMaxEnergy;
    float currentMinEnergy;

    float currentDamage;
  
    #region Properties
    public float Health
    {
        get { return currentHealth; }
        set { currentHealth = value; }
    }
    public float MinHealth
    {
        get { return currentMinHealth; }
        set { currentMinHealth = value; }
    }
    public float MaxHealth
    {
        get { return currentMaxHealth; }
        set { currentMaxHealth = value; }
    }
    public float Experience
    {
        get { return currentExp; }
        set { currentExp = value; }
    }
    public float MaxExperience
    {
        get { return currentMaxExp; }
        set { currentMaxExp = value; }
    }
    public int Level
    {
        get { return currentLvl; }
        set { currentLvl = value; }
    }
    public float Energy
    {
        get { return currentEnergy; }
        set { currentEnergy = value; }
    }
    public float MinEnergy
    {
        get { return currentMinEnergy; }
        set { currentMinEnergy = value; }
    }
    public float MaxEnergy
    {
        get { return currentMaxEnergy; }
        set { currentMaxEnergy = value; }
    }
    public float Damage
    {
        get { return currentDamage; }
        set { currentDamage = value; }
    }
    #endregion

    #region Constructor
    public PlayerStats(float health, float minHealth, float maxHealth, float exp, float maxExp, int level, float energy, float maxEnergy, float minEnergy, float damage)
    {
        currentHealth = health;
        currentMinHealth = minHealth;
        currentMaxHealth = maxHealth;
        currentExp = exp;
        currentMaxExp = maxExp;
        currentLvl = level;
        currentEnergy = energy;
        currentMinEnergy = minEnergy;
        currentMaxEnergy = maxEnergy;
        currentDamage = damage;
    }
    #endregion

    #region Methods

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }

    public void HealPlayer(float heal)
    {
        if(currentHealth < MaxHealth)
        {
            currentHealth += heal;
        }
        else if(currentHealth >= MaxHealth)
        {
            currentHealth = MaxHealth;
            Debug.Log("Already have max hp");
        }
    }

    public void LevelUp(float exp)
    {
        if(currentExp < currentMaxExp)
        {
            currentExp += exp;
        }
        else if(currentExp >= currentMaxExp)
        {
            currentExp = currentMaxExp;
            currentExp = 0;
            Level++;
            GameManager.gameManager.DisplayCards();
            // LevelUpStats(Level);

        }

    }

    public void LevelUpStats(int level)
    {
        IncreaseHealth(level);
        IncreaseEnergy(level);
        IncreaseDamage(level);
    }


    public void IncreaseHealth(int level)
    {
        MaxHealth += (Health * 0.01f) * ((100 - level) * 0.01f);
        Health = MaxHealth;
        Debug.Log("Your current Health is " + MaxHealth);
    }
    public void IncreaseEnergy(int level)
    {
        MaxEnergy += (Energy * 0.01f) * ((100 - level) * 0.01f);
        Energy = MaxEnergy;
    }
    public void IncreaseDamage(int level)
    {
        Damage += (Damage * 0.5f) * ((100 - level) * 0.01f);
        Debug.Log("Your current Damage is " + Damage);
    }
    #endregion

}
