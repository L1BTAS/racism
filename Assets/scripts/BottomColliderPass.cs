using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomColliderPass : MonoBehaviour
{
    private GameObject player;
    private GameObject block;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        block = GameObject.FindGameObjectWithTag("angryblock");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && player.GetComponent<MovementCarPlayer>().enabled == false)
        {
            player.GetComponent<BoxCollider2D>().isTrigger = true;
            player.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
        else if(collision.gameObject.tag == "angryblock")
        {
            block.GetComponent<BoxCollider2D>().isTrigger = true;
            block.GetComponent<Rigidbody2D>().gravityScale = 1;
            Debug.Log("block trigger");
        }
    }
}
