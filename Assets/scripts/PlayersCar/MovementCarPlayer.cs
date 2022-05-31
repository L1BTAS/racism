using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCarPlayer : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    Vector2 movement;

    [SerializeField] private float SpeedDown = 1f;
    [SerializeField] private float SpeedLeftRight = 1f;
    [SerializeField] private float SpeedUp = 1f;
    [SerializeField] private float diagonal = 1f;
    private float kaif;

    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            kaif = SpeedLeftRight;
        }

        else if (Input.GetKey(KeyCode.W))
        {
            kaif = SpeedUp;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            kaif = SpeedDown;
        }

        if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            kaif = diagonal;
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            kaif = diagonal;
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            kaif = diagonal;
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            kaif = diagonal;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * kaif * Time.fixedDeltaTime);
    }
}

