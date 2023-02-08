using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    float speed = 100;

    void FixedUpdate()
    {
        
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        float y = -1 * Time.fixedDeltaTime * speed;
        Vector2 newPosition = other.GetComponent<Rigidbody2D>().position + Vector2.up * y;
        other.GetComponent<Rigidbody2D>().MovePosition(newPosition);
        other.GetComponent<MovementCarPlayer>().mapBottom = -9f;


    }
    private void OnTriggerExit2D(Collider2D other)
    {

        other.GetComponent<Rigidbody2D>().gravityScale = 0;
        other.GetComponent<MovementCarPlayer>().mapBottom = -5.5f;


    }
}
