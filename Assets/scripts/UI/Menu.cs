using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem; 

public class Menu : MonoBehaviour
{
    PlayerControls controls;

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;
    public GameObject looseMenu;
    public TextMeshProUGUI ScoreText;
    public float ScoreAmount;
    public float ScoreIncrease;

    public GameObject player;

    private String[] music = { "NightLife", "RetroWave", "Hardbeat", "DarkTheme", "Anime" };

    void Start()
    {
        Time.timeScale = 1f;

        ScoreAmount = 0f;

        ScoreIncrease = 1f;
    }

    void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.Pause.performed += ctx => PauseMenu();
    }

    void Update()
    {
        
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        if (looseMenu != null)
        {
            if (player == null)
            {
                looseMenu.SetActive(true);
                FindObjectOfType<AudioManager>().Pause(music[PlayerPrefs.GetInt("selectedCar")]);
                FindObjectOfType<AudioManager>().Pause("EngineSound");
                Time.timeScale = 0.25f;
                Time.fixedDeltaTime = Time.timeScale * .02f;
            }
        }


        
            if (player != null)
            {
                if (GameIsPaused)
                {
                
                //player.GetComponent<CarRotate>().enabled = true;
                }
                else
                {
                
                //player.GetComponent<CarRotate>().enabled = false;
                }
            }

  
        if (ScoreText!=null)
        {
            ScoreText.text = (int)ScoreAmount + "";
            ScoreAmount += ScoreIncrease * (Time.timeSinceLevelLoad) / 1000;

            if (player == null || GameIsPaused)
            {
                ScoreIncrease = 0;
            }
            else
            {
                ScoreIncrease = 1f;
            }
        }
        
    }

    void PauseMenu()
    {
        if (pauseMenuUI != null)
        {
            if (GameIsPaused)
            {
                pauseMenuUI.SetActive(false);
                optionsMenuUI.SetActive(false);
                Time.timeScale = 1f;
                GameIsPaused = false;



                FindObjectOfType<AudioManager>().Play(music[PlayerPrefs.GetInt("selectedCar")]);
                FindObjectOfType<AudioManager>().Play("EngineSound");
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
        SceneManager.LoadScene(0);
        //Resume();
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SelectCar()
    {
        SceneManager.LoadScene(1);
        //Resume();
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
