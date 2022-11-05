using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set;}
    public static bool gameIsPaused = false;

    public PlayerUI playerUI;
    public PlayerBehaviour playerBehaviour;
    public PlayerStats playerStats = new PlayerStats(100, 0, 100, 0, 100, 1, 100, 100, 0, 25);
    public Enemy enemy;
    
    public UIBehaviour UIInterface;
    public GameObject pauseMenuUI;
    public GameObject gameOverMenuUI;

    EnemySpawn enemySpawn;

    public float time;

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
}
