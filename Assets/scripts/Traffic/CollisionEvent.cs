using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

public class CollisionEvent : MonoBehaviour
{
    private string[] players = {"Player0", "Player1", "Player2", "Player3", "Player4", "Player5" };
    private GameObject crashedPlayer;

    void ControlLost()
    {
        if (players.Length != 0)
        {
            crashedPlayer.GetComponent<CarControl>().enabled = false;
            crashedPlayer.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            CameraShake.Shake(0.1f, 0.1f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (players.Contains(collision.gameObject.tag))
        {
            crashedPlayer = collision.gameObject;
            FindObjectOfType<AudioManager>().Play("bump");
            ControlLost();
        }
    }
}