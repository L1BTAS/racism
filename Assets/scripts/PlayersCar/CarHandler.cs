using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CarHandler : MonoBehaviour
{
    CarControl carControl;

    public GameObject[] carPrefabs;
    public Transform[] spawnPoint;
    
    public int selectedCar = 0;
    private int spawn;
    private string playerTag;
    private string handlerTag;
    private int gameStarted = 0;
    
    void Start()
    {
        selectedCar = 0;
        PlayerPrefs.SetInt("selectedCar", selectedCar);
        carControl = GameObject.Instantiate(carPrefabs[selectedCar], spawnPoint[PlayerPrefs.GetInt("spawn")].position, Quaternion.identity).GetComponent<CarControl>();
        spawn = PlayerPrefs.GetInt("spawn");
        playerTag = ("Player" + PlayerPrefs.GetInt("spawn"));
        handlerTag = ("Handler" + PlayerPrefs.GetInt("spawn"));
        carControl.tag = (playerTag);
        gameObject.tag = (handlerTag);
        PlayerPrefs.SetInt("spawn", PlayerPrefs.GetInt("spawn") + 1);
        gameStarted++;
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        if(carControl)
        {
            carControl.onMove(ctx.ReadValue<Vector2>());
        }
    }

    public void Lights()
    {
        carControl.LightsOn();
    }

    public void NextCar(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if(SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 2)
            {                
                selectedCar = (selectedCar + 1) % carPrefabs.Length;
                PlayerPrefs.SetInt("selectedCar", selectedCar);
                Destroy(GameObject.FindGameObjectWithTag(playerTag));
                carControl = Instantiate(carPrefabs[selectedCar], spawnPoint[spawn].position, Quaternion.identity).GetComponent<CarControl>();
                carControl.tag = (playerTag);
            }
        }
    }

    public void SpawnCar(InputAction.CallbackContext ctx)
    {
        if (carControl == null)
        {
            if (SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 2)
            {
                Destroy(GameObject.FindGameObjectWithTag(playerTag));
                carControl = Instantiate(carPrefabs[selectedCar], spawnPoint[spawn].position, Quaternion.identity).GetComponent<CarControl>();
                carControl.tag = (playerTag);
            }
        }
    }

    public void previousCar(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if (SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 2)
            {
                selectedCar--;
                if (selectedCar < 0)
                {
                    selectedCar += carPrefabs.Length;
                }
                PlayerPrefs.SetInt("selectedCar", selectedCar);
                Destroy(GameObject.FindGameObjectWithTag(playerTag));
                carControl = Instantiate(carPrefabs[selectedCar], spawnPoint[spawn].position, Quaternion.identity).GetComponent<CarControl>();
                carControl.tag = (playerTag);
            }
        }
    }

    public void PlayGame(InputAction.CallbackContext ctx)
    {
        if (SelectionMenu.playersCount != 0)
        {
            SceneManager.LoadScene(3, LoadSceneMode.Single);
        }
    }
}
