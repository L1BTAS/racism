using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{


    void Start()
    {
         
    }



    private void OnTriggerStay2D(Collider2D other)
    {
       
            other.GetComponent<Rigidbody2D>().gravityScale = 30;

        
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {

        other.GetComponent<Rigidbody2D>().gravityScale = 0;



    }
}
