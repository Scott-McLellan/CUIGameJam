using UnityEngine;

public class GameStateController : MonoBehaviour
{
    public GameState currentState;
    
    
    public GameObject mainMenuPanel;
    public GameObject gameUIPanel;
    public GameObject pauseMenuPanel;
    public GameObject gameOverPanel;
    
    public AudioSource audioSource;
    public AudioClip mainMenuSound;
    public AudioClip playSound;
    public AudioClip pauseSound;
    public AudioClip gameOverSound;
    
    public TMPro.TextMeshProUGUI gameOverText;

    public enum GameState
    {
        MainMenu,
        Playing,
        Pause,
        GameOver
    }

    public void ChangeGameState(GameState state)
    {
        currentState = state;
        
        mainMenuPanel.SetActive(false);
        gameUIPanel.SetActive(false);
        pauseMenuPanel.SetActive(false);
        gameOverPanel.SetActive(false);

        if (currentState == GameState.MainMenu)
        {
            mainMenuPanel.SetActive(true);
            audioSource.PlayOneShot(mainMenuSound);
            Time.timeScale = 0;
            Debug.Log("Main Menu State");
        }

        if (currentState == GameState.Playing)
        {
            mainMenuPanel.SetActive(false);
            gameOverPanel.SetActive(false);
            gameUIPanel.SetActive(true);
            audioSource.PlayOneShot(playSound);
            Time.timeScale = 1;
            Debug.Log("Playing State");
        }

        if (currentState == GameState.Pause)
        {
            gameUIPanel.SetActive(false);
            pauseMenuPanel.SetActive(true);
            audioSource.PlayOneShot(pauseSound);
            Time.timeScale = 0;
            Debug.Log("Pause State");
        }

        if (currentState == GameState.GameOver)
        {
            gameOverPanel.SetActive(true);
            audioSource.PlayOneShot(gameOverSound);
            Time.timeScale = 0;
            Debug.Log("Game Over State");
        }
        
        
    }

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ChangeGameState(GameState.MainMenu);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == GameState.Playing)
        {
            CheckForWinner();
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentState == GameState.Playing)
            {
                ChangeGameState(GameState.Pause);
            }
            else if (currentState == GameState.Pause)
            {
                ChangeGameState(GameState.Playing);
            }
        }
    }

    private void CheckForWinner()
    {
        if (GameManager.Instance.player1Score == 5)
        {
            ChangeGameState(GameState.GameOver);
            gameOverText.text = "Player One Wins!";
        }
        else if (GameManager.Instance.player2Score == 5)
        {
            ChangeGameState(GameState.GameOver);
            gameOverText.text = "Player Two Wins!";
        }
    }

    public void StartGame()
    {
        GameManager.Instance.ResetGame();
        ChangeGameState(GameState.Playing);
    }

    public void PauseGame()
    {
        ChangeGameState(GameState.Pause);
    }

    public void ResumeGame()
    {
        ChangeGameState(GameState.Playing);
    }

    public void RestartGame()
    {
        GameManager.Instance.ResetGame();
        ChangeGameState(GameState.Playing);
    }

    public void EndGame()
    {
        ChangeGameState(GameState.GameOver);
    }

    public void MainMenu()
    {
        ChangeGameState(GameState.MainMenu);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
