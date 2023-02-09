using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderCollision : MonoBehaviour
{

    private GameObject player;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CameraShake.Shake(0.1f, 0.1f);
        }
    }
}
