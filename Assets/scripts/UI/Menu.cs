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

    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;
    public GameObject looseMenu;
    public TextMeshProUGUI ScoreText;
    public float ScoreAmount;
    public float ScoreIncrease=0f;

    public int spawn = 0;

    private int playersCount = 1;

    private String[] music = { "NightLife", "RetroWave", "Hardbeat", "DarkTheme", "Anime", "Hardbass", "Pixel" };

    void Start()
    {

        PlayerPrefs.SetInt("spawn", spawn);
        Time.timeScale = 1f;

        ScoreAmount = 0f;


        playersCount = 6;
    }

    void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.Pause.performed += ctx => PauseMenu();
        
    }

    void Update()
    {
      


        
        playersCount = 6;
        for (int i = 0; i < 6; i++)
        {
            if(GameObject.FindGameObjectWithTag("Player"+i) == null)
            {
                playersCount -= 1;
            }
            
           
                
        }
            
        

        if (looseMenu != null)
        {
            if (playersCount == 0)
            {
                looseMenu.SetActive(true);
                FindObjectOfType<AudioManager>().Pause(music[PlayerPrefs.GetInt("selectedCar")]);
                FindObjectOfType<AudioManager>().Pause("EngineSound");
                Time.timeScale = 0.25f;
                Time.fixedDeltaTime = Time.timeScale * .02f;
            }
        }


        if (ScoreText!=null)
        {
            if (playersCount != 0 && !GameIsPaused && SceneManager.GetActiveScene().buildIndex==3)
            {
                ScoreIncrease = 1f;
                ScoreText.text = (int)ScoreAmount + "";
                ScoreAmount += ScoreIncrease * (Time.timeSinceLevelLoad) / 1000;
            }
            else 
            {
                ScoreIncrease = 0f;
            }
                
            
            
        }
        
    }

    void PauseMenu()
    {
        if (pauseMenuUI != null)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                pauseMenuUI.SetActive(true);

                GameIsPaused = true;

                FindObjectOfType<AudioManager>().Pause(music[PlayerPrefs.GetInt("selectedCar")]);
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
        playersCount = 6;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        FindObjectOfType<AudioManager>().Play(music[PlayerPrefs.GetInt("selectedCar")]);
        FindObjectOfType<AudioManager>().Play("EngineSound");
    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }

}
