using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class SelectionMenu : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1f;
    }
    public void StartGame()
    {

        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}
