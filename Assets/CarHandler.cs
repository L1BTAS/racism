using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarHandler : MonoBehaviour
{
    CarControl carControl;

    public GameObject[] carPrefabs;
    public Transform[] spawnPoint;

    public int selectedCar = 0;
    private int spawn;
    private string playerTag;

    void Start()
    {
        selectedCar = 0;
        carControl = GameObject.Instantiate(carPrefabs[selectedCar], spawnPoint[PlayerPrefs.GetInt("spawn")].position, Quaternion.identity).GetComponent<CarControl>();       
        spawn = PlayerPrefs.GetInt("spawn");
        playerTag = ("Player" + PlayerPrefs.GetInt("spawn"));
        carControl.tag = (playerTag);
        PlayerPrefs.SetInt("spawn", PlayerPrefs.GetInt("spawn")+1);
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        carControl.onMove(ctx.ReadValue<Vector2>());
    }

    public void Lights()
    {
        carControl.LightsOn();
    }

    public void NextCar(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            selectedCar = (selectedCar + 1) % carPrefabs.Length;
            Destroy(GameObject.FindGameObjectWithTag(playerTag));
            carControl = Instantiate(carPrefabs[selectedCar], spawnPoint[spawn].position, Quaternion.identity).GetComponent<CarControl>();
            carControl.tag = (playerTag);

        }

    }

    public void previousCar(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            selectedCar--;
            if (selectedCar < 0)
            {
                selectedCar += carPrefabs.Length;
            }
            Destroy(GameObject.FindGameObjectWithTag(playerTag));
            carControl = Instantiate(carPrefabs[selectedCar], spawnPoint[spawn].position, Quaternion.identity).GetComponent<CarControl>();
            carControl.tag = (playerTag);
        }
        
    }
    
}
