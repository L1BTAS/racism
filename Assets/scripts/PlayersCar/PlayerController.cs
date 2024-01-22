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

    public float mapWidth = 6f; //ширина карты
    public float mapTop = 5f; //верхняя граница карты
    public float mapBottom = -5.5f; //нижняя граница карты
    public int selectedCar = 0; //Выбранная машинка

    [SerializeField] private float speed = 30f; //скорость перемещения машинки

    Quaternion target = Quaternion.Euler(0, 0, 0f); //стандартное положение машинки

    private void Awake()
    {
        controls = new PlayerControls();
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        rb = GetComponent<Rigidbody2D>(); //присваеваем ригидбади переменной
    }

    public void OnMove(InputAction.CallbackContext ctx) //получаем направление вектора с органа управления
    {
        move = ctx.ReadValue<Vector2>(); //записываем значение с органа управления в переменную
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

    public void NextCar(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            carPrefabs[selectedCar].SetActive(false); //деактивируем текущий префаб
            selectedCar = (selectedCar + 1) % carPrefabs.Length; //при достижении максимального элемента получаем остаток 0 и возвращаемся к первому элементу массива
            carPrefabs[selectedCar].SetActive(true); //активируем префаб идущий следующим
        }
        
    }

    public void PreviousCar(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            carPrefabs[selectedCar].SetActive(false); //деактивируем текущий префаб
            selectedCar--; //опускаемся на элемент ниже
            if (selectedCar < 0) //если значение меньше нуля, возвращаеся к последнему элементу в массиве
            {
                selectedCar += carPrefabs.Length;
            }
            carPrefabs[selectedCar].SetActive(true); //активируем новый префаб
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
