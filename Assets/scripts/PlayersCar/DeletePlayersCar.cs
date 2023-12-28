using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeletePlayersCar : MonoBehaviour
{
    public float passedTime = 0;
    Quaternion target = Quaternion.Euler(0, 0, 0f);

    public Color Color1;
    public Color Color2;

    public GameObject[] Lights;

    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            Lights[i].GetComponent<UnityEngine.Rendering.Universal.Light2D>().color = Color2;
        }
    }

    void FixedUpdate()
    {
        if (GetComponent<CarControl>().enabled == false)
        {
            if (passedTime <= 1.5)
            {
                for (int i = 0; i < 4; i++)
                {
                    Lights[i].GetComponent<UnityEngine.Rendering.Universal.Light2D>().color = Color.Lerp(Color2, Color1, Mathf.PingPong(Time.time, 0.8f));
                }
                passedTime += Time.deltaTime;
            }
            else
            {
                passedTime = 0;
                GetComponent<CarControl>().enabled = true;
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                for (int i = 0; i < 4; i++) 
                {
                    Lights[i].GetComponent<UnityEngine.Rendering.Universal.Light2D>().color = Color2;
                }
            }
        }
        else
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, target, 50 * Time.deltaTime);
        }


        if (transform.position.y < -8.3)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, target, 1000);
            this.gameObject.GetComponent<CarControl>().enabled = false;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            passedTime = 5;
        }
    }
}
