using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public int id;
    private void Start()
    {
        GameEvents.current.onDoorTriggerEnter += OnDoorOpen;
        GameEvents.current.onDoorTriggerExit += OnDoorClose;

    }
    private void OnDoorOpen(int id)
    {
        if(id == this.id)
        {
            GetComponent<Animator>().Play("Open");
        }

    }
    private void OnDoorClose(int id)
    {
        if (id == this.id)
        {
            GetComponent<Animator>().Play("Close");
        }
    }
}
