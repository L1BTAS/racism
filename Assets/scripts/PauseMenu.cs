using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;
    public GameObject looseMenu;

    public GameObject player;

    void Start()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
        
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        if (player == null)
        {
            looseMenu.SetActive(true);
            FindObjectOfType<AudioManager>().Pause("LoveIsInDanger");
            FindObjectOfType<AudioManager>().Pause("EngineSound");
            Time.timeScale = 0.25f;
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        if (player != null)
        {
            player.GetComponent<CarRotate>().enabled = true;
        }
        

        FindObjectOfType<AudioManager>().Play("LoveIsInDanger");
        FindObjectOfType<AudioManager>().Play("EngineSound");
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

        player.GetComponent<CarRotate>().enabled = false;

        FindObjectOfType<AudioManager>().Pause("LoveIsInDanger");
        FindObjectOfType<AudioManager>().Pause("EngineSound");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        Resume();
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
}