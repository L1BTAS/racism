using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GroundSelection : MonoBehaviour
{
    public GameObject[] grounds;
    public int selectedGround = 0;

    public void NextGround()
    {
        grounds[selectedGround].SetActive(false);
        selectedGround = (selectedGround + 1) % grounds.Length;
        grounds[selectedGround].SetActive(true);
    }

    public void PreviousGround()
    {
        grounds[selectedGround].SetActive(false);
        selectedGround--;
        if (selectedGround < 0)
        {
            selectedGround += grounds.Length;
        }
        grounds[selectedGround].SetActive(true);
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("selectedGround", selectedGround);
        PlayerPrefs.SetString("GameMode", "multiplayer");
    }
}
