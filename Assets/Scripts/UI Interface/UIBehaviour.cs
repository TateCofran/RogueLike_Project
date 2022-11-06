using TMPro;
using UnityEngine;

public class UIBehaviour : MonoBehaviour
{
    GameManager gameManager;

    [SerializeField] PlayerStats playerStats;
    
    [SerializeField] TextMeshProUGUI enemyCount;
    public int enemyKills = 0;
    
    [SerializeField] TextMeshProUGUI timeTxt;  

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();

    }
    private void Start()
    {
        enemyCount.text = enemyKills.ToString();
    }
    void Update()
    {
        
        timeTxt.text = gameManager.time.ToString("f0");
    }
    public void KillsCount()
    {
        enemyKills++;
        enemyCount.text = enemyKills.ToString();
    }
    
}
