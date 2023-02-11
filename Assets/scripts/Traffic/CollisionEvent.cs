using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEvent : MonoBehaviour
{
    private GameObject player;
    private float passedTime = 2;

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        
    }


    void Update()
    {

        passedTime += Time.deltaTime;
        if (player != null)
        {
            if (passedTime <= 1.5)
            {

                player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                
                ControlLost();

            }
            else
            {

                player.GetComponent<CarControl>().enabled = true;
                //player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;

            }

        }

    }

    void ControlLost()
    {
        if (player != null)
        {
            player.GetComponent<CarControl>().enabled = false;
            CameraShake.Shake(0.1f, 0.1f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            passedTime = 0;
        }
    }
}