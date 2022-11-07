using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIBehaviour : MonoBehaviour
{
    GameManager gameManager;

    [SerializeField] PlayerStats playerStats;
    
    [SerializeField] TextMeshProUGUI enemyCount;
    [HideInInspector] public int enemyKills = 0;
    
    [SerializeField] TextMeshProUGUI timeTxt;

    [SerializeField] GameObject clearedRoom;
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
    
    public IEnumerator ShowText()
    {
        clearedRoom.SetActive(true);
        yield return new WaitForSeconds(5);
        clearedRoom.SetActive(false);
    }
}
