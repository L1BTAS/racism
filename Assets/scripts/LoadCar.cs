using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCar : MonoBehaviour
{
    public GameObject[] carPrefabs;
    public Transform spawnPoint;

    void Start()
    {
        int selectedCar = PlayerPrefs.GetInt("selectedCar");
        GameObject prefab = carPrefabs[selectedCar];
        GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
    }

}
