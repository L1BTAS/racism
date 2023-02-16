using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTraffic : MonoBehaviour
{
    private float Speed = 4f;
    private Rigidbody2D rb;

    Quaternion target = Quaternion.Euler(0, 0, 0f);
    void FixedUpdate()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -Speed - Time.timeSinceLevelLoad / 25);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, target, 50 * Time.deltaTime);
        if (transform.position.y < -10)
        {
            Destroy(this.gameObject);
        }
    }
}
