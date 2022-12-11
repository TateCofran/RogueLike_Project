using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRoom : MonoBehaviour
{
    public int id;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            LevelManager.instance.currentRoom = gameObject;
            gameObject.GetComponent<EnemySpawn>().GenerateWave();

            if(LevelManager.instance.currentRoom == GameObject.FindGameObjectWithTag("Boss Room"))
            {
                LevelManager.instance.state = LevelManager.State.Boss;
                //LevelManager.instance.BossRoom();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            GameEvents.current.DoorTriggerExit(id);

        }
    }
}
