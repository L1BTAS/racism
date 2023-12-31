using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Experimental.Rendering.Universal;

[RequireComponent(typeof(CharacterController))]
public class CarControl : MonoBehaviour
{

    PlayerControls controls;

    private Vector2 move;

    private Rigidbody2D rb;

    public GameObject[] Lights;

    public float mapWidth = 6f;
    public float mapTop = 5f;
    public float mapBottom = -5.5f;

    [SerializeField] private float speed = 30f;

    Quaternion target = Quaternion.Euler(0, 0, 0f);

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Awake()
    {
        controls = new PlayerControls();
        controls.Gameplay.Lights.canceled += ctx => LightsOff();
    }

    void FixedUpdate()
    {
        
        if (transform.position.x > mapWidth)
        {
            transform.position = new Vector2(mapWidth, transform.position.y);
        }

        if (transform.position.x < -mapWidth)
        {
            transform.position = new Vector2(-mapWidth, transform.position.y);
        }

        if (transform.position.y > mapTop)
        {
            transform.position = new Vector2(transform.position.x, mapTop);
        }
        if (transform.position.y < mapBottom)
        {
            transform.position = new Vector2(transform.position.x, mapBottom);
        }

        rb.velocity = move*speed;

        //if (transform.position.y < -8.3)
        //{
        //    Destroy(this.gameObject);
        //}
    }
    
    public void onMove(Vector2 value)
    {
        move = value;
    }

    public void LightsOn()
    {
        if(!Menu.GameIsPaused)
        {
            Lights[0].GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = 5;
            Lights[1].GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = 5;
            Lights[0].GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightOuterRadius = 1.1f;
            Lights[1].GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightOuterRadius = 1.1f;
        }
        
    }

    void LightsOff()
    {
        Lights[0].GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = 1;
        Lights[1].GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = 1;
        Lights[0].GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightOuterRadius = 0.8f;
        Lights[1].GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightOuterRadius = 0.8f;
    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}
