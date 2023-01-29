using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeletePlayersCar : MonoBehaviour
{
    public GameObject music;

    void FixedUpdate()
    {
        if (transform.position.y < -20)
        {
            Destroy(this.gameObject);
            music.SetActive(false);
            SceneManager.LoadScene(0);
        }
    }
}
