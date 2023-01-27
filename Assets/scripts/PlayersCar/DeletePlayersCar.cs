using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeletePlayersCar : MonoBehaviour
{

    void FixedUpdate()
    {
        if (transform.position.y < -20)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(0);
        }
    }
}
