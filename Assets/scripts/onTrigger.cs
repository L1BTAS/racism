using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.GetComponent<CollisionEvent>().enabled == true)
        {
            collision.GetComponent<BoxCollider2D>().isTrigger = false;
            collision.GetComponent<Rigidbody2D>().gravityScale = 0;
            
        }

    }
}
