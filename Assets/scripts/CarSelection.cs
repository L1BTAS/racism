using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class CarSelection : MonoBehaviour
{

    public GameObject[] cars;
    public int selectedCar = 0;
    public TextMeshProUGUI SelectCarText;

    public void nextCar()
    {
        cars[selectedCar].transform.position = new Vector3(0,0,0);

        cars[selectedCar].SetActive(false);
        selectedCar = (selectedCar + 1) % cars.Length;
        cars[selectedCar].SetActive(true);


        if (SelectCarText != null)
        {
            SelectCarText.text = cars[selectedCar].name;
        }
    }

    public void previousCar()
    {
        cars[selectedCar].transform.position = new Vector3(0, 0, 0);

        cars[selectedCar].SetActive(false);
        selectedCar--;
        if(selectedCar < 0)
        {
            selectedCar += cars.Length;
        }
        cars[selectedCar].SetActive(true);

        if (SelectCarText != null)
        {
            SelectCarText.text = cars[selectedCar].name;
        }
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("selectedCar", selectedCar);
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}
