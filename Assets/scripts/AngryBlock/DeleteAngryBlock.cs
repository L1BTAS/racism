using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAngryBlock : MonoBehaviour
{



    void FixedUpdate()
    {
        if (transform.position.y < -17)
        {
            Destroy(this.gameObject);

        }
    }
}
