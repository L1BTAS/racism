using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEvent : MonoBehaviour
{
    private GameObject player;
    private float passedTime;
    public bool isCrash = false;
    //public float gravity = 1f; для падения

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        passedTime += Time.deltaTime;
        if (player != null)
        {
            if (passedTime < 1)
            {
                if (isCrash == true)
                {
                    FunctionTimer.Create(ControlLost, 1f);

                }
            }
            else
            {
                isCrash = false;
                //player.GetComponent<MovementCarPlayer>().enabled = true;
                //player.GetComponent<CarRotate>().enabled = true;
            }
        }


        //Debug.Log(passedTime);

    }

    void ControlLost()
    {
        if (player != null)
        {
            //player.GetComponent<MovementCarPlayer>().enabled = false;
            //player.GetComponent<CarRotate>().enabled = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            passedTime = 0;
            isCrash = true;
            //player.GetComponent<Rigidbody2D>().gravityScale = 2; не реалистично
            //player.velocity = new Vector2(0, -Speed - Time.timeSinceLevelLoad / 10); не работает
        }
    }
}

