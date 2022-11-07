using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;


    [SerializeField] GameObject[] levels;
    [SerializeField] GameObject[] enemiesInCurrentRoom;
    bool roomCleared = false;

    [HideInInspector] UIBehaviour UIBehaviour;
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    void Start()
    {
        levels = GameObject.FindGameObjectsWithTag("Room");
        UIBehaviour = FindObjectOfType<UIBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (roomCleared == false)
        {
            EnemiesRoom();
        }
        else
        {
            return;
        }

    }

    public void EnemiesRoom()
    {
        enemiesInCurrentRoom = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemiesInCurrentRoom.Length <= 0)
        {
            StartCoroutine(UIBehaviour.ShowText());
            roomCleared = true;
        }
    }

}
