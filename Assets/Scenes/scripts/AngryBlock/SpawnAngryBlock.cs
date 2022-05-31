using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAngryBlock : MonoBehaviour
{
    public GameObject AngryBlock;
    public float RespawnTime = 1f;
    public float difficult = 0.10f;
    private void Start()
    {
        StartCoroutine(Difficult());
        StartCoroutine(AngryBlockWave());

    }
    
    private void SpawnAngryBlocks()
    {
        GameObject b = Instantiate(AngryBlock) as GameObject;
        b.transform.position = new Vector3(Random.Range(-6.4f, 5.5f), 12f, 0.5f);
    }
    IEnumerator AngryBlockWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(RespawnTime);
            SpawnAngryBlocks();
        }
    }
    IEnumerator Difficult()
    {
        if (RespawnTime > difficult)
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                RespawnTime -= 0.005f;
            }
        }
    }




}
