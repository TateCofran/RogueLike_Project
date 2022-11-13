
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    EnemySpawn enemySpawn;

    public List<GameObject> rooms = new List<GameObject>();
    [SerializeField] GameObject[] enemiesInCurrentRoom;
    //[SerializeField] GameObject[] triggerRooms;
    public bool roomCleared = false;

    [HideInInspector] UIBehaviour UIBehaviour;

    [SerializeField] GameObject player;

    public GameObject door;
    public Animator doorAnim;

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
            doorAnim.Play("Open");
        }
    }
}