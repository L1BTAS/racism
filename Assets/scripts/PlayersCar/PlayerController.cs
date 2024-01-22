using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerController : MonoBehaviour
{
    PlayerControls controls;
    private Vector2 move;
    private Rigidbody2D rb;

    public GameObject[] carPrefabs;
    public GameObject[] Lights;
    public Transform[] multiSpawnPoints;
    public Transform[] singleSpawnPoint;

    public float mapWidth = 6f; //������ �����
    public float mapTop = 5f; //������� ������� �����
    public float mapBottom = -5.5f; //������ ������� �����
    public int selectedCar = 0; //��������� �������

    [SerializeField] private float speed = 30f; //�������� ����������� �������

    Quaternion target = Quaternion.Euler(0, 0, 0f); //����������� ��������� �������

    private void Awake()
    {
        controls = new PlayerControls();
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        rb = GetComponent<Rigidbody2D>(); //����������� ��������� ����������
    }

    public void OnMove(InputAction.CallbackContext ctx) //�������� ����������� ������� � ������ ����������
    {
        move = ctx.ReadValue<Vector2>(); //���������� �������� � ������ ���������� � ����������
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
            transform.position = new Vector2(transform.position.x, mapBottom); //������� ������� �� �����
        }

        rb.velocity = move * speed; //���������� �������
    }

    public void NextCar(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            carPrefabs[selectedCar].SetActive(false); //������������ ������� ������
            selectedCar = (selectedCar + 1) % carPrefabs.Length; //��� ���������� ������������� �������� �������� ������� 0 � ������������ � ������� �������� �������
            carPrefabs[selectedCar].SetActive(true); //���������� ������ ������ ���������
        }
        
    }

    public void PreviousCar(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            carPrefabs[selectedCar].SetActive(false); //������������ ������� ������
            selectedCar--; //���������� �� ������� ����
            if (selectedCar < 0) //���� �������� ������ ����, ����������� � ���������� �������� � �������
            {
                selectedCar += carPrefabs.Length;
            }
            carPrefabs[selectedCar].SetActive(true); //���������� ����� ������
        }
        
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
