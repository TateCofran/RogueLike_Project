
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    EnemySpawn enemySpawn;

    public List<GameObject> rooms = new List<GameObject>();
    [SerializeField] GameObject[] enemiesInCurrentRoom;

    public GameObject currentRoom;

    [HideInInspector] UIBehaviour UIBehaviour;
    [HideInInspector] TriggerRoom triggerRoom;
    [SerializeField] GameObject player;
    

    //public GameObject door;
    //public Animator doorAnim;

    public enum State {  Fighting, Cleared }
    public State state;

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
        UIBehaviour = FindObjectOfType<UIBehaviour>();
        
    }



    // Update is called once per frame
    void Update()
    {
        triggerRoom = currentRoom.GetComponent<TriggerRoom>();
        switch (state)
        {
            /*case State.Start:
                enemySpawn.GenerateWave();
                state = State.Fighting;
                break;*/
            case State.Fighting:           
                triggerRoom.doorAnim.Play("Close");
                break;

            case State.Cleared:
                StartCoroutine(UIBehaviour.ShowText());
                triggerRoom.doorAnim.Play("Open");                   
                break;

            default:
                break;
        }

        Invoke("EnemiesRoom", 2f);
       
    }
    public void EnemiesRoom()
    {
        enemiesInCurrentRoom = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemiesInCurrentRoom.Length > 0)
        {
            state = State.Fighting;
        }
        else
        {
            state = State.Cleared;
        }

    }
}