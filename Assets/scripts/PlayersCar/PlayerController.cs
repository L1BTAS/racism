using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    PlayerControls controls;
    private Vector2 move;
    private Rigidbody2D rb;

    public GameObject[] carPrefabs;
    public GameObject[] Lights;
    public Transform[] multiSpawnPoints;
    public Transform[] singleSpawnPoint;

    public float teleportDistance = 5f; //��������� ���������
    public float mapWidth = 6f; //������ �����
    public float mapTop = 5f; //������� ������� �����
    public float mapBottom = -5.5f; //������ ������� �����
    public int selectedCar = 0; //��������� �������
    private int spawn; //����� ������
    private string playerTag; //���������� ���� ������
    private bool ReadyToStart = false; //���������� ��� �������� ������� ������� �� �����


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
        PlayerPrefs.SetInt("selectedCar", selectedCar); //������� ���������� ����������
        spawn = PlayerPrefs.GetInt("spawn"); //������ ����� ������
        playerTag = ("Player" + PlayerPrefs.GetInt("spawn")); //������� �������� ��� ������
        gameObject.tag = (playerTag); //����������� �������� ��� ������
        PlayerPrefs.SetInt("spawn", PlayerPrefs.GetInt("spawn") + 1); //����������� ����� ������ �� 1
        ReadyToStart = true;

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
            PlayerPrefs.SetInt("selectedCar", selectedCar); //���������� � ���������� ���������� ��� �������� � �����
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
            PlayerPrefs.SetInt("selectedCar", selectedCar); //���������� � ��������� ���������� ��� �������� � �����
            carPrefabs[selectedCar].SetActive(true); //���������� ����� ������
        }
        
    }

    public void PlayGame(InputAction.CallbackContext ctx)
    {
        if (ReadyToStart == true)
        {
            SceneManager.LoadScene(3, LoadSceneMode.Single);
        }
    }

    public void Blink(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            // �������� ������� ������� ���������
            Vector2 currentPosition = rb.position;

            // ��������� ����� ������� � ������ ����������� �������� � ���������� ������������
            Vector2 newPosition = currentPosition + move * teleportDistance;

            // ������������� ���������
            rb.MovePosition(newPosition);
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
