using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Timeline.Actions.MenuPriority;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set;}
    public static bool gameIsPaused = false;

    public PlayerUI playerUI;
    public PlayerBehaviour playerBehaviour;
    public PlayerStats playerStats = new PlayerStats(100, 0, 100, 0, 100, 1, 100, 100, 0, 25);
    
    [HideInInspector] public Enemy enemy;
    
    public UIBehaviour UIInterface;
    public GameObject pauseMenuUI;
    public GameObject gameOverMenuUI;

    [HideInInspector]public float time;

    //prueba
    [SerializeField] GameObject[] enemiesInCurrentRoom;
    bool roomCleared = false;

    public Transform cardSpawn;
    [SerializeField] GameObject cardItem;
    [HideInInspector] CardDisplay cardDisplay;
    int maxCardDisplay = 1;

    void Awake()
    {
        if (gameManager != null && gameManager != this)
        {
            Destroy(this);
        }
        else
        {
            gameManager = this;
        }
    }
    private void Start()
    {
        UIInterface = FindObjectOfType<UIBehaviour>();
        enemy = FindObjectOfType<Enemy>();
        gameIsPaused = false;
        Cursor.visible = false;
    }
    private void Update()
    {
        if (roomCleared == false)
        {
            EnemiesRoom();
        }
        else
        {
            return;
        }


        time += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();

            }
            else
            {
                Pause();

            }
        }
        if(playerStats.Health <= 0)
        {
            gameOverMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    public void Resume()
    {
        time += Time.deltaTime;

        pauseMenuUI.SetActive(false);

        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
        
        gameOverMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Quit()
    {
        Debug.Log("You close the game");
    }


    public void EnemiesRoom()
    {
        enemiesInCurrentRoom = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemiesInCurrentRoom.Length <= 0)
        {
            Debug.Log("You cleared the room, go to the next room");
            roomCleared = true;
        }
    }

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
            Time.timeScale = 0f;
            gameIsPaused = true;
        }
    }
}
