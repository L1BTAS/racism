using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using System.Linq;

public class Menu : MonoBehaviour
{
    PlayerControls controls;
    public static bool GameIsPaused = false;
    public bool GameIsLoosed = false;
    public GameObject pauseMenuUI;
    public Transform[] playerSpawnPoints;
    public GameObject optionsMenuUI;
    public GameObject looseMenuSingle;
    public GameObject looseMenuMulti;
    public GameObject AcceptionMenuUI;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI maxScore;
    public bool isAcceptionMenuActive;
    public float ScoreAmount;
    public float ScoreIncrease=0f;
  
    public int spawn = 0;

    //private int playersCount = 1;

    private String[] music = { "NightLife", "RetroWave", "Hardbeat", "DarkTheme", "Anime", "Hardbass", "Pixel" };
    private String[] playerTags = { "Player0", "Player1", "Player2", "Player3", "Player4", "Player5" };
    List<string> alivePlayers = new List<string>();

    void Start()
    {

        PlayerPrefs.SetInt("spawn", spawn);

        Time.timeScale = 1f;
        ScoreAmount = 0f;

        //playersCount = 6;
        if (maxScore != null)
        {
            maxScore.text = "HIGHSCORE: " + (int)PlayerPrefs.GetFloat("MaxScore");

        }

        for (int i = 0; i < 6; i++)
        {
            if (GameObject.FindGameObjectWithTag(playerTags[i]) != null)
            {
                alivePlayers.Add(playerTags[i]);
               
            }
        }

    }

    void Awake()
    {
        controls = new PlayerControls();
        controls.Gameplay.Pause.performed += ctx => PauseMenu();
    }

    void Update()
    {
        //playersCount = alivePlayers.Count;
        for (int i = 0; i < alivePlayers.Count; i++)
        {
            if (GameObject.FindGameObjectWithTag(alivePlayers[i]).transform.position.y <= -8.3)
            {
                alivePlayers.Remove(alivePlayers[i]);
            }
        }
        isAcceptionMenuActive = AcceptionMenuUI.activeInHierarchy;

        if (looseMenuSingle != null && PlayerPrefs.GetString("GameMode")=="singleplayer")
        {
            if (GameObject.FindGameObjectWithTag("Player0").transform.position.y <= -8.3)
            {
                looseMenuSingle.SetActive(true);
                FindObjectOfType<AudioManager>().Pause(music[PlayerPrefs.GetInt("selectedCar")]);
                FindObjectOfType<AudioManager>().Pause("EngineSound");
                Time.timeScale = 0.25f;
                Time.fixedDeltaTime = Time.timeScale * .02f;
                GameIsLoosed = true;
            }
        }

        if (looseMenuMulti != null && PlayerPrefs.GetString("GameMode") == "multiplayer")
        {
            if (alivePlayers.Count == 0)
            {
                looseMenuMulti.SetActive(true);
                FindObjectOfType<AudioManager>().Pause(music[PlayerPrefs.GetInt("selectedGround")]);
                FindObjectOfType<AudioManager>().Pause("EngineSound");
                Time.timeScale = 0.25f;
                Time.fixedDeltaTime = Time.timeScale * .02f;
                GameIsLoosed = true;
            }
        }

        if (ScoreText!=null)
        {
            if (!GameIsLoosed && !GameIsPaused && SceneManager.GetActiveScene().buildIndex==3)
            {
                ScoreIncrease = 1f;
                ScoreText.text = (int)ScoreAmount + "";
                ScoreAmount += ScoreIncrease * (Time.timeSinceLevelLoad) / 1000;

                if (ScoreAmount > PlayerPrefs.GetFloat("MaxScore"))
                {
                    PlayerPrefs.SetFloat("MaxScore", ScoreAmount);
                    
                   
                }
            }
            else 
            {
                ScoreIncrease = 0f;
            }
        }

        
    }

    void PauseMenu()
    {
        if (pauseMenuUI != null && GameIsLoosed == false)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                pauseMenuUI.SetActive(true);

                GameIsPaused = true;
                if (PlayerPrefs.GetString("GameMode") == "singleplayer")
                {
                    FindObjectOfType<AudioManager>().Pause(music[PlayerPrefs.GetInt("selectedCar")]);
                }
                else if (PlayerPrefs.GetString("GameMode") == "multiplayer")
                {
                    FindObjectOfType<AudioManager>().Pause(music[PlayerPrefs.GetInt("selectedGround")]);
                }
                FindObjectOfType<AudioManager>().Pause("EngineSound");
                Time.timeScale = 0f;
            }
            
        }
        
    }

    public void LoadMenu()
    {
        for (int i = 0; i < 6; i++)
        {
            Destroy(GameObject.FindGameObjectWithTag("Player" + i));
            Destroy(GameObject.FindGameObjectWithTag("Handler" + i));
        }
        Resume();
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void Restart()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        
        for (int i = 0; i < 6; i++)
        {
            if (GameObject.FindGameObjectWithTag(playerTags[i]) != null)
            {
                GameObject.FindGameObjectWithTag(playerTags[i]).transform.position = playerSpawnPoints[i].position;
            }
        }

    }

    public void SelectCar()
    {
        SceneManager.LoadScene(1);
    }

    public void Singleplayer()
    {
        PlayerPrefs.SetString("GameMode", "singleplayer");
        SceneManager.LoadScene(1);
    }

    public void Multiplayer()
    {
        SceneManager.LoadScene(2);
    }

    public void Resume()
    {
        if (!isAcceptionMenuActive)
        {
            pauseMenuUI.SetActive(false);
            optionsMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
            if (PlayerPrefs.GetString("GameMode") == "singleplayer")
            {
                FindObjectOfType<AudioManager>().Play(music[PlayerPrefs.GetInt("selectedCar")]);
            }
            else if (PlayerPrefs.GetString("GameMode") == "multiplayer")
            {
                FindObjectOfType<AudioManager>().Play(music[PlayerPrefs.GetInt("selectedGround")]);
            }

            FindObjectOfType<AudioManager>().Play("EngineSound");
        }
        
    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
        //хуй говно моча и жопа
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}
