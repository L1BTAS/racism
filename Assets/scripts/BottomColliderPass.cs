using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BottomColliderPass : MonoBehaviour
{
    private GameObject player;
    
    void Start() { 

        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (player == null)
        {
            if (collision.GetComponent<CollisionEvent>().enabled == true)
            {
                collision.GetComponent<BoxCollider2D>().isTrigger = true;
                collision.GetComponent<Rigidbody2D>().gravityScale = 1;
                
            }
        }

        else if (player.GetComponent<MovementCarPlayer>().enabled == false)
        {
            player.GetComponent<BoxCollider2D>().isTrigger = true;
            player.GetComponent<Rigidbody2D>().gravityScale = 1;
        }

        if (collision.GetComponent<CollisionEvent>().enabled == true)
        {
            collision.GetComponent<BoxCollider2D>().isTrigger = true;
            collision.GetComponent<Rigidbody2D>().gravityScale = 1;
            
        }

    }
}
