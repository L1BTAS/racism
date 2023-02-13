using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTraffic : MonoBehaviour
{
    private float Speed = 6f;
    private Rigidbody2D rb;

    Quaternion target = Quaternion.Euler(0, 0, 0f);
    void Update()
    {

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -Speed - Time.timeSinceLevelLoad / 50);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, target, 50 * Time.deltaTime);
        //print(-Speed - Time.timeSinceLevelLoad / 5);
        if (transform.position.y < -17)
        {
            Destroy(this.gameObject);
        }
    }
}
