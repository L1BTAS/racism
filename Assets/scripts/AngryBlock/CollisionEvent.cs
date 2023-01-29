using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEvent : MonoBehaviour
{
    private GameObject player;
    //public float gravity = 1f; для падения

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void ControlLost()
    {
        player.GetComponent<MovementCarPlayer>().enabled = false;
        player.GetComponent<CarRotate>().enabled = false;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ControlLost();
            //player.GetComponent<Rigidbody2D>().gravityScale = 2; не реалистично
            //player.velocity = new Vector2(0, -Speed - Time.timeSinceLevelLoad / 10); не работает
        }
    }
}

