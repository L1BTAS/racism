using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAngryBlock : MonoBehaviour
{
    public float Speed = 1f;
    private Rigidbody2D rb;
    void Update()
    {

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -Speed - Time.timeSinceLevelLoad / 10);

    }
}
