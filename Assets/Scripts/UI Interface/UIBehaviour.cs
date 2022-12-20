using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class UIBehaviour : MonoBehaviour
{
    GameManager gameManager;
    LevelManager levelManager;

    [SerializeField] PlayerStats playerStats;

    [SerializeField] TextMeshProUGUI enemyCount;
    [HideInInspector] public int enemyKills = 0;

    [SerializeField] TextMeshProUGUI timeTxt;

    [SerializeField] public GameObject clearedRoom;

    //[SerializeField] public GameObject bossEnemyUI;
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        levelManager = FindObjectOfType<LevelManager>();
    }
    private void Start()
    {
        enemyCount.text = enemyKills.ToString();

    }
    void Update()
    {

        timeTxt.text = gameManager.time.ToString("f0");
        ShowText();
        
    }
    public void KillsCount()
    {
        enemyKills++;
        enemyCount.text = enemyKills.ToString();
    }

    public void ShowText()
    {
        if (LevelManager.instance.state == LevelManager.State.Fighting)
        {
            clearedRoom.SetActive(false);
        }
        else if (LevelManager.instance.state == LevelManager.State.Cleared)
        {
            clearedRoom.SetActive(true);
        }
        else if(LevelManager.instance.state == LevelManager.State.Boss)
        {
            clearedRoom.SetActive(false);
        }
    }
}
