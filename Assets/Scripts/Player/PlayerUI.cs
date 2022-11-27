using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] Slider healthSlider;
    [SerializeField] Slider manaSlider;
    [SerializeField] Image expFiller;

    [SerializeField] TextMeshProUGUI level;
    [SerializeField] TextMeshProUGUI currentExp;
    [SerializeField] TextMeshProUGUI currentMana;
    [SerializeField] TextMeshProUGUI currentHealth;

    [SerializeField] TextMeshProUGUI dashCountTxt;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        level.text = gameManager.playerStats.Level.ToString();
        currentHealth.text = gameManager.playerStats.Health.ToString("F0") + "/" + gameManager.playerStats.MaxHealth.ToString("F0");
        currentMana.text = gameManager.playerStats.Mana.ToString("F0") + "/" + gameManager.playerStats.MaxMana.ToString("F0");
        currentExp.text = gameManager.playerStats.Experience + "/" + gameManager.playerStats.MaxExperience;
        dashCountTxt.text = "Dash " + gameManager.playerController.dashAmount.ToString() + "/" + gameManager.playerController.maxDashAmount.ToString();
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

    public void SetMaxMana(float maxMana)
    {
        manaSlider.maxValue = maxMana;
        manaSlider.value = maxMana;
    }
    public void SetMana(float mana)
    {
        manaSlider.value = mana;
    }

    public void SetMinLevel(float minExp)
    {
        expFiller.fillAmount = minExp;
    }
    public void SetExp(float exp)
    {
        expFiller.fillAmount = exp / gameManager.playerStats.MaxExperience;
    }
}
