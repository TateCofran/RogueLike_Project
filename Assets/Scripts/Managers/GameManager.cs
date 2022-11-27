using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set;}
    public static bool gameIsPaused = false;
    public static bool gameIsOver = false;

    //Player
    public PlayerUI playerUI;
    public PlayerBehaviour playerBehaviour;
    public PlayerStats playerStats = new PlayerStats(100, 0, 100, 0, 100, 1, 100, 100, 0, 25, 15);
    [HideInInspector] public PlayerController playerController;

    //Enemy
    [HideInInspector] public Enemy enemy;
    
    //Interface
    public UIBehaviour UIInterface;
    public GameObject pauseMenuUI;
    public GameObject gameOverMenuUI;
    [HideInInspector]public float time;



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
        playerController = FindObjectOfType<PlayerController>();
        UIInterface = FindObjectOfType<UIBehaviour>();
        enemy = FindObjectOfType<Enemy>();
        gameIsPaused = false;
        Cursor.visible = false;
    }
    private void Update()
    {
        time += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused && gameIsOver == false)
            {
                Resume();

            }
            else if (gameIsOver == false)
            {
                Pause();

            }
        }
        if(playerStats.Health <= 0)
        {
            gameOverMenuUI.SetActive(true);
            Time.timeScale = 0f;
            gameIsOver = true;
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
        gameIsOver = false;
        gameIsPaused = false;
        Time.timeScale = 1f;
    }
    public void Quit()
    {
        Debug.Log("You close the game");
    }
}
