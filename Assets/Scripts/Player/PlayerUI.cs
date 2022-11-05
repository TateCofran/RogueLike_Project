using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] Slider healthSlider;
    [SerializeField] Slider energySlider;
    [SerializeField] Image expFiller;
    [SerializeField] Image abilityFiller;

    [SerializeField] TextMeshProUGUI level;
    [SerializeField] TextMeshProUGUI currentExp;
    [SerializeField] TextMeshProUGUI currentEnergy;
    [SerializeField] TextMeshProUGUI currentHealth;

    private void Update()
    {
        level.text = GameManager.gameManager.playerStats.Level.ToString();
        currentHealth.text = GameManager.gameManager.playerStats.Health + "/" + GameManager.gameManager.playerStats.MaxHealth;
        currentEnergy.text = GameManager.gameManager.playerStats.Energy.ToString("F0") + "/" + GameManager.gameManager.playerStats.MaxEnergy;
        currentExp.text = GameManager.gameManager.playerStats.Experience + "/" + GameManager.gameManager.playerStats.MaxExperience;
    }
    public void SetMaxHealth(float maxHealth)
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
    }
    public void SetHealth(float health)
    {
        healthSlider.value = health;
    }

    public void SetMaxEnergy(float maxEnergy)
    {
        energySlider.maxValue = maxEnergy;
        energySlider.value = maxEnergy;
    }
    public void SetEnergy(float energy)
    {
        energySlider.value = energy;
    }

    public void SetMinLevel(float minExp)
    {
        expFiller.fillAmount = minExp;
    }
    public void SetExp(float exp)
    {
        expFiller.fillAmount = exp / GameManager.gameManager.playerStats.MaxExperience;
    }
    public void SetCooldown(float cooldown)
    {
        abilityFiller.gameObject.SetActive(true);
        abilityFiller.fillAmount -= 1 / cooldown * Time.deltaTime;
        if(abilityFiller.fillAmount == 0)
        {
            abilityFiller.gameObject.SetActive(false);
        }
    }
}
