using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] PlayerUI playerUI;
    Enemy enemy;

    private void Start()
    {
        enemy = FindObjectOfType<Enemy>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerTakeDamage();
            Debug.Log(GameManager.gameManager.playerStats.Health);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            PlayerHeal(10);
            Debug.Log(GameManager.gameManager.playerStats.Health);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            PlayerGainExp(100);
            Debug.Log(GameManager.gameManager.playerStats.Experience);
        }
        if(GameManager.gameManager.playerStats.Energy <= GameManager.gameManager.playerStats.MaxEnergy)
        {
            GameManager.gameManager.playerStats.Energy += 1 * Time.deltaTime;
        }
        else
        {
            GameManager.gameManager.playerStats.Energy = GameManager.gameManager.playerStats.MaxEnergy;
        }
    }

    public void PlayerTakeDamage()
    {
        GameManager.gameManager.playerStats.TakeDamage(15);
        playerUI.SetHealth(GameManager.gameManager.playerStats.Health);
    }

    public void PlayerHeal(float healing)
    {
        GameManager.gameManager.playerStats.HealPlayer(healing);
        playerUI.SetHealth(GameManager.gameManager.playerStats.Health);
    }

    public void PlayerGainExp(float exp)
    {
        GameManager.gameManager.playerStats.LevelUp(exp);
        playerUI.SetExp(GameManager.gameManager.playerStats.Experience);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("BulletEnemy"))
        {
            GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
            float enemyDamage = enemy.GetComponentInParent<Enemy>().damage;

            GameManager.gameManager.playerStats.Health -= enemyDamage;
            GameManager.gameManager.playerUI.SetHealth(GameManager.gameManager.playerStats.Health);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
            float enemyDamage = enemy.GetComponentInParent<Enemy>().damage;

            GameManager.gameManager.playerStats.Health -= enemyDamage;
            GameManager.gameManager.playerUI.SetHealth(GameManager.gameManager.playerStats.Health);
        }
    }

    private void Death()
    {
        if(GameManager.gameManager.playerStats.Health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("You are Dead");
        }
    }
}
