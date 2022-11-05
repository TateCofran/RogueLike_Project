using TMPro;
using UnityEngine;

public class UIBehaviour : MonoBehaviour
{
    public Transform cardSpawn;

    [SerializeField] PlayerStats playerStats;
    [SerializeField] CardDisplay cardDisplay;
    int maxCardDisplay = 1;
    

    [SerializeField] TextMeshProUGUI enemyCount;
    public int enemyKills = 0;

    [SerializeField] TextMeshProUGUI timeTxt;

    

    GameManager gameManager;
    
    //Prueba
    [SerializeField] GameObject cardItem;

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
    
    
    //Cambiar a GameManager
    public void DisplayCards()
    {
        var loadCards = Resources.LoadAll("Cards", typeof(CardStats));
        foreach (var card in loadCards)           
        {
            for (int i = 0; i < maxCardDisplay; i++)
            {
                int randomCard = Random.Range(0, 1);
                CardDisplay newCard = Instantiate(cardItem, cardSpawn.position, Quaternion.identity, cardSpawn).GetComponent<CardDisplay>();
                newCard.card = (CardStats)card;
            }
            Cursor.visible = true;
            GameManager.gameManager.Pause();
        }
    }

}
