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

    float currentMana;
    float currentMaxMana;
    float currentMinMana;

    float currentDamage;
    float currentMagicDamage;
  
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
    public float Mana
    {
        get { return currentMana; }
        set { currentMana = value; }
    }
    public float MinMana
    {
        get { return currentMinMana; }
        set { currentMinMana = value; }
    }
    public float MaxMana
    {
        get { return currentMaxMana; }
        set { currentMaxMana = value; }
    }
    public float Damage
    {
        get { return currentDamage; }
        set { currentDamage = value; }
    }
    public float MagicDamage
    {
        get { return currentMagicDamage; }
        set { currentMagicDamage = value; }
    }
    #endregion

    #region Constructor
    public PlayerStats(float health, float minHealth, float maxHealth, float exp, float maxExp, int level, float mana, float maxMana, float minMana, float damage, float magicDamage)
    {
        currentHealth = health;
        currentMinHealth = minHealth;
        currentMaxHealth = maxHealth;
        currentExp = exp;
        currentMaxExp = maxExp;
        currentLvl = level;
        currentMana = mana;
        currentMinMana = minMana;
        currentMaxMana = maxMana;
        currentDamage = damage;
        currentMagicDamage = magicDamage;
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
            CardManager.instance.DrawCard();
            //GameManager.gameManager.DisplayCards();
            LevelUpStats(Level);

        }

    }

    public void LevelUpStats(int level)
    {
        IncreaseHealth(level);
        IncreaseMana(level);
        IncreaseDamage(level);
        IncreaseMagicDamage(level);
        Debug.Log("Your Current stats are: " + " Health : " + MaxHealth + ", Mana: " + MaxMana + ", Damage: " + Damage + ", Magic Damage: " + MagicDamage);
    }


    public void IncreaseHealth(int level)
    {
        MaxHealth += (Health * 0.01f) * ((100 - level) * 0.01f);
        Health = MaxHealth;
        
    }
    public void IncreaseMana(int level)
    {
        MaxMana += (Mana * 0.01f) * ((100 - level) * 0.01f);
        Mana = MaxMana;
    }
    public void IncreaseDamage(int level)
    {
        Damage += (Damage * 0.5f) * ((100 - level) * 0.01f);

    }
    public void IncreaseMagicDamage(int level)
    {
        MagicDamage += (MagicDamage * 0.5f) * ((100 - level) * 0.01f); 
    }
    #endregion

}
