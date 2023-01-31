using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeletePlayersCar : MonoBehaviour
{
    public GameObject loosePanel;

    void FixedUpdate()
    {
        
        if (transform.position.y < -17)
        {

            Destroy(this.gameObject);

        }
    }
}
