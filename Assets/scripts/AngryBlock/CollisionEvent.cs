using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEvent : MonoBehaviour
{
    private GameObject player;

    public GameObject Score;
    //public float gravity = 1f; для падения

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }
    
    
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                player.GetComponent<ScoreCount>().enabled = false;
                player.GetComponent<MovementCarPlayer>().enabled = false;
                player.GetComponent<CarRotate>().enabled = false;

                //player.GetComponent<Rigidbody2D>().gravityScale = 2; не реалистично
                //player.velocity = new Vector2(0, -Speed - Time.timeSinceLevelLoad / 10); не работает
            }
        }
    
    
    

    
}

