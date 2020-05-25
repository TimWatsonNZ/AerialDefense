using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Menu,
        Running,
        GameOver,
    }

    public GameState gameState;
    public Level[] levels;

    public Menu menuPrefab;
    public Player playerPrefab;
    public GameOver gameOverPrefab;

    Player playerInstance;
    Menu menuInstance;
    GameOver gameOverInstance;

    Level currentLevel;

    int currentLevelIndex = -1;

    void Start()
    {
        gameState = GameState.Menu;

        menuInstance = Instantiate(menuPrefab, transform);
        menuInstance.gameManager = this;
    }

    public void PlayGame()
    {
        gameState = GameState.Running;
        playerInstance = Instantiate(playerPrefab, new Vector2(0, -Utility.GetScreenHeight() + 2), Quaternion.identity);
        playerInstance.transform.parent = transform;
        playerInstance.OnDeath += ShowGameOver;

        if (menuInstance != null)
        {
            menuInstance.gameObject.SetActive(false);
        }
        StartNewLevel();
    }

    public void Quit()
    {
        Application.Quit();
    }

    void ShowGameOver()
    {
        Destroy(playerInstance.gameObject);
        currentLevel.CleanUp();
        Destroy(currentLevel.gameObject);
        gameState = GameState.GameOver;
        gameOverInstance = Instantiate(gameOverPrefab);
    }

    void Update()
    {

        if (gameState == GameState.GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Destroy(gameOverInstance.gameObject);
                PlayGame();
            }
        }
    }

    void OnCurrentLevelEnd()
    {
        if (currentLevelIndex < levels.Length - 1)
        {
            StartNewLevel();
        }
    }

    void OnLevelEndScreenEnd()
    {

    }

    void StartNewLevel()
    {
        currentLevelIndex++;
        if (levels.Length > currentLevelIndex -1 )
        {
            currentLevel = Instantiate(levels[currentLevelIndex], transform);
            currentLevel.OnLevelEnd += OnCurrentLevelEnd;
        }
        
    }
}

