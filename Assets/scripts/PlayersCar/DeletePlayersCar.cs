using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeletePlayersCar : MonoBehaviour
{
    private float passedTime = 0;
    Quaternion target = Quaternion.Euler(0, 0, 0f);

    public Color Color1;
    public Color Color2;

    public GameObject[] Lights;

    void FixedUpdate()
    {
        if (GetComponent<CarControl>().enabled == false)
        {
            if (passedTime <= 1.5)
            {
                Lights[0].GetComponent<UnityEngine.Rendering.Universal.Light2D>().color = Color.Lerp(Color1, Color2, Mathf.PingPong(Time.time, 0.5f));
                Lights[1].GetComponent<UnityEngine.Rendering.Universal.Light2D>().color = Color.Lerp(Color1, Color2, Mathf.PingPong(Time.time, 0.5f));
                passedTime += Time.deltaTime;
            }
            else
            {
                passedTime = 0;
                GetComponent<CarControl>().enabled = true;
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
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
