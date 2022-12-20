
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    EnemySpawn enemySpawn;

    public List<GameObject> rooms = new List<GameObject>();
    [SerializeField] GameObject[] enemiesInCurrentRoom;

    public GameObject currentRoom;

    [HideInInspector] UIBehaviour UI;
    [HideInInspector] TriggerRoom triggerRoom;
    [SerializeField] public GameObject player;
    public enum State {  Fighting, Cleared, Boss }
    public State state;

    public bool bossActive = false;

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
        currentRoom = GameObject.Find("Spawn Room");
        
        enemySpawn = FindObjectOfType<EnemySpawn>();
        UI = FindObjectOfType<UIBehaviour>();

    }

    // Update is called once per frame
    void Update()
    {
        triggerRoom = currentRoom.GetComponent<TriggerRoom>();
        switch (state)
        {

            case State.Fighting:
                GameEvents.current.DoorTriggerExit(triggerRoom.id);
                break;
            case State.Cleared:
                GameEvents.current.DoorTriggerEnter(triggerRoom.id);
                break;
            case State.Boss:
                BossRoom();
                break;
            default:
                break;
        }

        Invoke("EnemiesRoom", 2f);
       
    }
    public void EnemiesRoom()
    {
        enemiesInCurrentRoom = GameObject.FindGameObjectsWithTag("Enemy");

        GameObject boss = GameObject.FindGameObjectWithTag("Boss Enemy");
        
        if (enemiesInCurrentRoom.Length > 0)
        {
            state = State.Fighting;
        }
        else if (enemiesInCurrentRoom.Length <= 0 && boss == false)
        {
            state = State.Cleared;
        }
        else if(bossActive == true)
        {
            state = State.Boss;
        }

    }
    public void BossRoom()
    {

            bossActive = true;

    }
}