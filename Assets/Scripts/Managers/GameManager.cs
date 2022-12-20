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
    [HideInInspector] public UIBehaviour UIInterface;
    public GameObject pauseMenuUI;
    public GameObject gameOverMenuUI;
    public GameObject WinScreenMenu;

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
        gameIsOver = false;
        Cursor.visible = false;
        AudioListener.volume = 1f;
        Time.timeScale = 1f;
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
            Cursor.visible = true;
            AudioListener.volume = 0f;

            gameIsOver = true;
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Cursor.visible = true;
        AudioListener.volume = 0.25f;
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    public void Resume()
    {
        time += Time.deltaTime;

        pauseMenuUI.SetActive(false);

        WinScreenMenu.SetActive(false);

        Cursor.visible = false;
        AudioListener.volume = 1f;

        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;

        gameOverMenuUI.SetActive(false);
        gameIsOver = false;
        gameIsPaused = false;
        
    }
    public void Quit()
    {
        Debug.Log("You close the game");
        Application.Quit();
    }

    public void WinMenu()
    {
        WinScreenMenu.SetActive(true);
        Cursor.visible = true;
        
        AudioListener.volume = 0f;
        
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
}
