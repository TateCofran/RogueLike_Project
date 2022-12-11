using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class BossEnemyUI : MonoBehaviour
{
    [SerializeField] public Slider healthSlider;
    [SerializeField] TextMeshProUGUI currentHealth;

    [SerializeField] EnemyBoss enemyBoss;

    private void Update()
    {
        currentHealth.text = enemyBoss.health.ToString("F0") + "/" + enemyBoss.maxHealth.ToString("F0");
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
}
