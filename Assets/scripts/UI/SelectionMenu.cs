using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class SelectionMenu : MonoBehaviour
{
    private int playersCount = 1;
    public GameObject playButton;

    void Start()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
        playersCount = 6;
        for (int i = 0; i < 6; i++)
        {
            if (GameObject.FindGameObjectWithTag("Player" + i) == null)
            {
                playersCount -= 1;
            }

        }

        if(playersCount == 0)
        {
            playButton.SetActive(false);
        }
        else
        {
            playButton.SetActive(true);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }

    public void LoadMenu()
    {
        for (int i = 0; i < 6; i++)
        {
            Destroy(GameObject.FindGameObjectWithTag("Player" + i));
            Destroy(GameObject.FindGameObjectWithTag("Handler" + i));
        }
        SceneManager.LoadScene(0);
    }
}
