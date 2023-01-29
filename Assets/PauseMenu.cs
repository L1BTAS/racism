using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;

    public GameObject player;


    void Update()
    {
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

        player.GetComponent<CarRotate>().enabled = true;

        AudioSource[] audios = FindObjectsOfType<AudioSource>();

        foreach(AudioSource a in audios)
        {
            a.Play();
        }
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

        player.GetComponent<CarRotate>().enabled = false;

        AudioSource[] audios = FindObjectsOfType<AudioSource>();

        foreach (AudioSource a in audios)
        {
            a.Pause();
        }
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
}
