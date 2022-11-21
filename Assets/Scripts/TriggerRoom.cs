using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRoom : MonoBehaviour
{
    GameObject player;
    EnemySpawn enemySpawn;
    [SerializeField] public GameObject door;
    [SerializeField] public Animator doorAnim;
    private void Awake()
    {
        doorAnim = door.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        enemySpawn = FindObjectOfType<EnemySpawn>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            LevelManager.instance.currentRoom = gameObject;
            gameObject.GetComponent<EnemySpawn>().GenerateWave();
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            doorAnim.Play("Close");

        }
    }
}
