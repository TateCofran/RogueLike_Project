using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] PlayerUI playerUI;
    Enemy enemy;
    GameManager gameManager;
    private void Start()
    {
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
            PlayerHeal(10);
            Debug.Log(gameManager.playerStats.Health);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            PlayerGainExp(100);
            Debug.Log(gameManager.playerStats.Experience);
        }
        if(gameManager.playerStats.Mana <=gameManager.playerStats.MaxMana)
        {
            GameManager.gameManager.playerStats.Mana += 1 * Time.deltaTime;
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
        /*if (other.gameObject.CompareTag("Enemy"))
        {
            GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
            float enemyDamage = enemy.GetComponentInParent<Enemy>().damage;

            gameManager.playerStats.TakeDamage(enemyDamage);
            gameManager.playerUI.SetHealth(gameManager.playerStats.Health);
        }*/
    }
}
