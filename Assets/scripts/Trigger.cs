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
        other.GetComponent<MovementCarPlayer>().mapBottom = -8.5f;



    }
    private void OnTriggerExit2D(Collider2D other)
    {

        other.GetComponent<Rigidbody2D>().gravityScale = 0;
        other.GetComponent<MovementCarPlayer>().mapBottom = -5.5f;


    }
}
