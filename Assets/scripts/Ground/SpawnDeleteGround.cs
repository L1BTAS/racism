using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDeleteGround : MonoBehaviour
{
    public GameObject Ground;
    public static bool IsDeleted = true;
    private void SpawnGrounds()
    {
        GameObject b = Instantiate(Ground) as GameObject;
        b.transform.position = new Vector3(0, 12f, 1.5f);

    }

    public void FixedUpdate()
    {
        if (IsDeleted == true)
        {
            SpawnGrounds();
            IsDeleted = false;

        }
        else if (Ground.transform.position.y < -12)
        {
            Destroy(Ground);
            IsDeleted = true;
        }
    }

}
