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
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log(gameObject.transform.parent.name);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(LevelManager.instance.roomCleared == false)
        {
            LevelManager.instance.doorAnim.Play("Close");
        }
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log(gameObject.transform.parent.name);
        }

        //LevelManager.instance.rooms.RemoveAt(0);
        //LevelManager.instance.CurrentRoom();
    }
}
