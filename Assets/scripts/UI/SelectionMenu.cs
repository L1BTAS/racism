using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class SelectionMenu : MonoBehaviour
{
    private int playersCount = 1;
    public GameObject playButton;
    public TextMeshProUGUI PressAnyButton;
    public TextMeshProUGUI QE;


    public Color Color1;  /*прозрачный цвет*/
    public Color Color2;  /*норм цвет*/
    public Color Color3;  /*полупрозрачный цвет*/

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
        

        if (playersCount == 0)
        {
            playButton.SetActive(false);
            PressAnyButton.color = Color.Lerp(Color1, Color2, Mathf.PingPong(Time.time, 1));
            QE.color = Color1;
        }
        else
        {
            playButton.SetActive(true);
            PressAnyButton.color = Color1;
            QE.color = Color3;
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
