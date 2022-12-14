using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] PlayerUI playerUI;
    PlayerMagicSystem magicSystem;
    Enemy enemy;
    GameManager gameManager;
    private void Start()
    {
        magicSystem = GetComponent<PlayerMagicSystem>();
        gameManager = FindObjectOfType<GameManager>();
        enemy = FindObjectOfType<Enemy>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerTakeDamage();
            Debug.Log(gameManager.playerStats.Health);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            PlayerHeal(25);
            Debug.Log(gameManager.playerStats.Health);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            PlayerGainExp(100);
            Debug.Log(gameManager.playerStats.Experience);
        }
        if(gameManager.playerStats.Mana < gameManager.playerStats.MaxMana)
        {
            GameManager.gameManager.playerStats.Mana += magicSystem.manaCharge * Time.deltaTime * 2;
        }
        else
        {
            gameManager.playerStats.Mana = gameManager.playerStats.MaxMana;
        }
    }

    public void PlayerTakeDamage()
    {
        gameManager.playerStats.TakeDamage(15);
        playerUI.SetHealth(gameManager.playerStats.Health);
    }

    public void PlayerHeal(float healing)
    {
        gameManager.playerStats.HealPlayer(healing);
        playerUI.SetHealth(gameManager.playerStats.Health);
    }

    public void PlayerGainExp(float exp)
    {
        gameManager.playerStats.LevelUp(exp);
        playerUI.SetExp(gameManager.playerStats.Experience);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("BulletEnemy"))
        {
            GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
            float enemyDamage = enemy.GetComponentInParent<Enemy>().damage;

            gameManager.playerStats.TakeDamage(enemyDamage);
            gameManager.playerUI.SetHealth(gameManager.playerStats.Health);
        }
    }

}
