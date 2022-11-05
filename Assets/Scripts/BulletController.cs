using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    
    [SerializeField] float speed = 45f;
    float timeToDestroy;


    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        timeToDestroy += 1 * Time.deltaTime;

        if (timeToDestroy >= 1.5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            //health enemy
        }
        if(other.gameObject.CompareTag ("Player"))
        {
            //GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
            //float enemyDamage = enemy.GetComponentInParent<Enemy>().damage;
            
            //GameManager.gameManager.playerStats.Health -= enemyDamage;
            //GameManager.gameManager.playerUI.SetHealth(GameManager.gameManager.playerStats.Health);
            Destroy(gameObject);
        }
    }
}
