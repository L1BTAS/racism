using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour
{
    public float Speed = 1f;
    public float Accleration = 5;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(0, -Speed - Time.timeSinceLevelLoad / Accleration);
    }
}
