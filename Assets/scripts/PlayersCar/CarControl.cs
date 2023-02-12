using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class CarControl : MonoBehaviour
{

    PlayerControls controls;

    Vector2 move;

    public GameObject[] Lights;

    [SerializeField] private float speed = 10f;

    public float mapWidth = 6f;
    public float mapTop = 5f;
    public float mapBottom = -5.5f;

    public void Awake()
    {
        controls = new PlayerControls();

        //controls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        //controls.Gameplay.Move.canceled += ctx => move = Vector2.zero;

        //controls.Gameplay.Lights.performed += ctx => LightsOn();
        controls.Gameplay.Lights.canceled += ctx => LightsOff();
    }

    void FixedUpdate()
    {
        transform.Translate(move, Space.World);
        if(transform.position.x > mapWidth)
        {
            transform.position = new Vector2(mapWidth, transform.position.y);
        }

        if(transform.position.x < -mapWidth)
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
    }

    public void onMove(Vector2 value)
    {
        move = value * Time.fixedDeltaTime * speed;
    }

    public void LightsOn()
    {
        Lights[0].GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = 5;
        Lights[1].GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = 5;
        Lights[0].GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightOuterRadius = 1.1f;
        Lights[1].GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightOuterRadius = 1.1f;
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
