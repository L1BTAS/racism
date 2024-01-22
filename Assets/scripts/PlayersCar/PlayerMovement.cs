using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerMovement : MonoBehaviour
{
    PlayerControls controls;
    private Vector2 move;
    [SerializeField] private Rigidbody2D rb;

    public GameObject[] Lights;

    public float mapWidth = 6f; //ширина карты
    public float mapTop = 5f; //верхняя граница карты
    public float mapBottom = -5.5f; //нижняя граница карты

    [SerializeField] private float speed = 30f; //скорость перемещения машинки

    Quaternion target = Quaternion.Euler(0, 0, 0f); //стандартное положение машинки

    private void Awake()
    {
        controls = new PlayerControls();
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        move = ctx.ReadValue<Vector2>();
    }

    private void FixedUpdate()
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
            transform.position = new Vector2(transform.position.x, mapBottom); //возврат машинки на карту
        }

        rb.velocity = move * speed; //премещение машинки
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
