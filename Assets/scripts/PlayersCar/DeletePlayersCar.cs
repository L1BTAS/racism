using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeletePlayersCar : MonoBehaviour
{
    public GameObject loosePanel;

    void FixedUpdate()
    {
        
        if (transform.position.y < -8.5)
        {

            Destroy(this.gameObject);

        }
    }
}
