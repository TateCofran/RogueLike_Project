using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRoom : MonoBehaviour
{
    GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        other = player.GetComponent<BoxCollider>();
        if(other != null && LevelManager.instance.roomCleared == true)
        {
            Debug.Log("Next Room");
            other.transform.position = LevelManager.instance.nextRoom.position + Vector3.up;
            LevelManager.instance.rooms.RemoveAt(0);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        other = player.GetComponent<BoxCollider>();
        if (other != null)
        {
            Debug.Log("Start 2 room");
            LevelManager.instance.roomCleared = false;
            LevelManager.instance.rooms[0].gameObject.GetComponentInChildren<EnemySpawn>().enabled = true;
        }
    }
}
