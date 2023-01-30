using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeletePlayersCar : MonoBehaviour
{
    

    void FixedUpdate()
    {
        if (transform.position.y < -17)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(0);
        }
    }
}
