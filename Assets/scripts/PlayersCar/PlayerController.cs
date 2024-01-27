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
    public GameObject[] BackLights;
    public Transform[] multiSpawnPoints; //список точек спавна для мультиплеера
    public Transform singleSpawnPoint; //точка спавна для синглплеера

    public float teleportDistance = 5f; //дистанция телепорта
    public float mapWidth = 6f; //ширина карты
    public float mapTop = 5f; //верхняя граница карты
    public float mapBottom = -5.5f; //нижняя граница карты
    public int selectedCar = 0; //Выбранная машинка
    private int spawn; //номер спавна
    private string playerTag; //переменная тега игрока
    private bool ReadyToStart = false; //переменная для проверки наличия игроков на сцене


    [SerializeField] private float speed = 30f; //скорость перемещения машинки

    Quaternion target = Quaternion.Euler(0, 0, 0f); //стандартное положение машинки

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Gameplay.Lights.canceled += ctx => LightsOff();
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        rb = GetComponent<Rigidbody2D>(); //присваеваем ригидбади переменной
        PlayerPrefs.SetInt("selectedCar", selectedCar); //создаем глобальную переменную
        spawn = PlayerPrefs.GetInt("spawn"); //задаем номер спавна
        playerTag = ("Player" + PlayerPrefs.GetInt("spawn")); //создаем номерной тег игроку
        gameObject.tag = (playerTag); //присваиваем номерной тег игроку
        PlayerPrefs.SetInt("spawn", PlayerPrefs.GetInt("spawn") + 1); //увеличиваем номер спавна на 1
        ReadyToStart = true;

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
            PlayerPrefs.SetInt("selectedCar", selectedCar); //записываем в глобальную переменную для привязки к карте
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
            PlayerPrefs.SetInt("selectedCar", selectedCar); //записываем в глобальую переменную для привязки к карте
            carPrefabs[selectedCar].SetActive(true); //активируем новый префаб
        }
        
    }

    public void PlayGame(InputAction.CallbackContext ctx)
    {
        if (ReadyToStart == true)
        {
            SceneManager.LoadScene(3, LoadSceneMode.Single);
        }
    }

    public void LightsOn(InputAction.CallbackContext ctx)
    {
        BackLights[0].GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = 5;
        BackLights[1].GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = 5;
        BackLights[0].GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightOuterRadius = 1.1f;
        BackLights[1].GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightOuterRadius = 1.1f;
    }

    void LightsOff()
    {
        BackLights[0].GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = 1;
        BackLights[1].GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = 1;
        BackLights[0].GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightOuterRadius = 0.8f;
        BackLights[1].GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightOuterRadius = 0.8f;
    }

    public void Blink(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            // Получаем текущую позицию персонажа
            Vector2 currentPosition = rb.position;

            // Вычисляем новую позицию с учетом направления движения и расстояния телепортации
            Vector2 newPosition = currentPosition + move * teleportDistance;

            // Телепортируем персонажа
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
