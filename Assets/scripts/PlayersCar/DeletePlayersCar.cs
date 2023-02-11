using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeletePlayersCar : MonoBehaviour
{
    private float passedTime = 0;
    Quaternion target = Quaternion.Euler(0, 0, 0f);

    void FixedUpdate()
    {
        if(GetComponent<CarControl>().enabled == false)
        {
            
            if(passedTime <= 1.5)
            {
                passedTime += Time.deltaTime;
            }
            else
            {
                passedTime = 0;
                GetComponent<CarControl>().enabled = true;
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;                  
            }
        }
        else
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, target, 50 * Time.deltaTime);
        }
        
        if (transform.position.y < -8.3)
        {

            Destroy(this.gameObject);

        }
    }
}
