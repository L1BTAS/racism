using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficSpawner : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject[] trafficPrefab;
    public float timeBetweenSpawns = 1f;

    private float timeToSpawn = 3f;

    void Update()
    {

        if(Time.time >= timeToSpawn)
        {
            SpawnTraffic();
            timeToSpawn = Time.time + timeBetweenSpawns- Time.timeSinceLevelLoad / 500;
        }

    }

    void SpawnTraffic()
    {
        int randomIndex2 = Random.Range(0, spawnPoints.Length);
        int randomIndex3 = Random.Range(0, spawnPoints.Length);
        int randomIndex = Random.Range(0, spawnPoints.Length);
        int randomTraffic = Random.Range(0, trafficPrefab.Length);
        int randomTraffic2 = Random.Range(0, trafficPrefab.Length);
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (randomIndex == i)
            {
                if (randomIndex == randomIndex2)
                {

                    Instantiate(trafficPrefab[randomTraffic2], spawnPoints[randomIndex3].position, Quaternion.identity);
                }
                Instantiate(trafficPrefab[randomTraffic], spawnPoints[i].position, Quaternion.identity);
            }
        }
    }

}
