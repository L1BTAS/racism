using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAngryBlock : MonoBehaviour
{
    public GameObject AngryBlock;

    [SerializeField] public float RespawnTime = 1f;
    //public float difficult = 0.10f;
    private float rand;
    private void Start()
    {
        //StartCoroutine(Difficult());
        StartCoroutine(AngryBlockWave());

    }
    
    private void SpawnAngryBlocks()
    {
        GameObject b = Instantiate(AngryBlock) as GameObject;
        b.transform.position = new Vector3(Random.Range(-6f, 6f), 12f, 0.5f);
        rand = Random.Range(4, 10);
        RespawnTime = rand / 12f;

    }
    IEnumerator AngryBlockWave()
    {
            while (true)
            {
                yield return new WaitForSeconds(RespawnTime);
                SpawnAngryBlocks();
            }
    }
   


   

}
