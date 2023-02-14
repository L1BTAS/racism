using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] trafficPrefab;
    public float timeBetweenSpawns = 1f;

    float timeToSpawn = 3f;
    private int previousSpawn;

    void Update()
    {
        if(Time.time >= timeToSpawn)
        {
            SpawnTraffic();
            timeToSpawn = Time.time + timeBetweenSpawns;
        }
    }

    void SpawnTraffic()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        int randomTraffic = Random.Range(0, trafficPrefab.Length);
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (randomIndex == i && previousSpawn != i)
            {
                Instantiate(trafficPrefab[randomTraffic], spawnPoints[i].position, Quaternion.identity);
                previousSpawn = i;
            }
        }
    }
}
