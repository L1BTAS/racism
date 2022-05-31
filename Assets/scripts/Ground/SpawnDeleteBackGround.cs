using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDeleteBackGround : MonoBehaviour
{
    public GameObject BackGround;
    public static bool IsDeleted = true;
    public float SpawnPosY = 12;
    public float SpawnPosX = 0;
    private void SpawnBackGrounds()
    {

        GameObject b = Instantiate(BackGround) as GameObject;

        b.transform.position = new Vector3(SpawnPosX, SpawnPosY, 1);

    }

    public void FixedUpdate()
    {
        if (IsDeleted == true)
        {
            SpawnBackGrounds();
            IsDeleted = false;

        }
        else if (BackGround.transform.position.y < -12)
        {
            Destroy(BackGround);
            IsDeleted = true;
        }
    }

}
