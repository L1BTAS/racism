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
        for (int i = 0; i < 6; i++)
        {
            Destroy(GameObject.FindGameObjectWithTag("Player" + i));
            Destroy(GameObject.FindGameObjectWithTag("Handler" + i));
        }
        SceneManager.LoadScene(0);
    }
}
