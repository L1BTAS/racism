using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCarPlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float SpeedDown = 1f;
    [SerializeField] private float SpeedLeftRight = 1f;
    [SerializeField] private float SpeedUp = 1f;
    [SerializeField] private float diagonal = 1f;
    public float mapWidth = 5f;
    public float mapTop = 5f;
    public float mapBottom = -5f;

    private float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            speed = SpeedLeftRight;
        }

        else if (Input.GetKey(KeyCode.W))
        {
            speed = SpeedUp;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            speed = SpeedDown;
        }

        if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            speed = diagonal;
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            speed = diagonal;
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            speed = diagonal;
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            speed = diagonal;
        }
    }

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal") * Time.fixedDeltaTime * speed;
        float y = Input.GetAxisRaw("Vertical") * Time.fixedDeltaTime * speed;
        Vector2 newPosition = rb.position + Vector2.right * x + Vector2.up * y;
        newPosition.x = Mathf.Clamp(newPosition.x, -mapWidth, mapWidth);
        newPosition.y = Mathf.Clamp(newPosition.y, mapBottom, mapTop);
        rb.MovePosition(newPosition);
    }
}

