using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    EnemySpawn enemySpawn;

    public List<GameObject> rooms = new List<GameObject>();
    [SerializeField] GameObject[] enemiesInCurrentRoom;
    public bool roomCleared = false;

    [HideInInspector] UIBehaviour UIBehaviour;

    public Transform nextRoom;
    [SerializeField] GameObject player;
    [SerializeField] GameObject triggerDoor;

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
        enemySpawn = FindObjectOfType<EnemySpawn>();
        //rooms = GameObject.FindGameObjectsWithTag("Room");
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
