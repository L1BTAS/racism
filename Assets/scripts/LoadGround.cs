using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGround : MonoBehaviour
{
    public GameObject[] groundPrefabs;
    public Transform spawnPoint;

    void Start()
    {
        if(PlayerPrefs.GetString("GameMode") == "singleplayer")
        {
            int selectedGround = PlayerPrefs.GetInt("selectedCar");
            GameObject prefab = groundPrefabs[selectedGround];
            GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        }
        else if(PlayerPrefs.GetString("GameMode") == "multiplayer")
        {
            int selectedGround = PlayerPrefs.GetInt("selectedGround");
            GameObject prefab = groundPrefabs[selectedGround];
            GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        }
      
    }

}
