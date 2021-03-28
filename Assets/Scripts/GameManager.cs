using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Player Variables
    public static GameObject player;
    [SerializeField, Tooltip("Set Player as Main/Spawn")] private GameObject playerInst;
    public static bool isDead = false;
    public static bool preventRentry = false;

    // Pause Variables
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject isOptionsOpen;
    public static bool isPaused;

    // Lose Screen Variable
    [SerializeField] private GameObject loseScreen;
    public static bool loseGame;

    // Win Screen Variable
    [SerializeField] private GameObject winScreen;
    public static bool winGame;

    //Main Menu Startup script
    [SerializeField] private MainMenu mmStart;

    private static GameManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("ERROR: There can only be one GameManager.");
            Destroy(gameObject);
        }

        if(player == null)
        {  
            SpawnPlayer();
        }

        if(pauseMenu == null)
        {
            pauseMenu = GameObject.FindGameObjectWithTag("PauseMenuUI");
        }
    }
    private void Start()
    {
        mmStart.onGameStart();
    }
    // Update is called once per frame
    private void Update()
    {
        if (isDead)
        {
            PlayerIsDestroyed();
        }

        // Pause Menu
        if (isPaused)
        {
            Pause();
        }
        else
        {
            Resume();
        }

        // Lose Screen
        if (loseGame)
        {
            LoseGame();
        }

        // Win Screen
        if (winGame)
        {
            WinGame();
        }

    }
    private void PlayerIsDestroyed()
    {
        Destroy(player, 5f);
        player = null;
        loseGame = true;
    }
    private void SpawnPlayer()
    {
        player = Instantiate(playerInst, gameObject.transform.position, Quaternion.identity);

        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        if(isOptionsOpen.activeSelf)
        {
            pauseMenu.SetActive(false);
        }
        else
        {
            pauseMenu.SetActive(true);
        }

    }
    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }
    public void LoseGame()
    {
        Time.timeScale = 0f;
        loseScreen.SetActive(true);
    }
    public void WinGame()
    {
        Time.timeScale = 0f;
        winScreen.SetActive(true);
    }    
    
}
