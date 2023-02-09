using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementCarPlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float SpeedDown = 1f;
    [SerializeField] private float SpeedLeftRight = 1f;
    [SerializeField] private float SpeedUp = 1f;
    [SerializeField] private float diagonal = 1f;
    [SerializeField] private GameObject[] Lights;
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
        Lights[0].GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = 1;
        Lights[1].GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = 1;
        Lights[0].GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightOuterRadius = 0.8f;
        Lights[1].GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightOuterRadius = 0.8f;

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
            Lights[0].GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = 5;
            Lights[1].GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = 5;
            Lights[0].GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightOuterRadius = 1.1f;
            Lights[1].GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightOuterRadius = 1.1f;
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

