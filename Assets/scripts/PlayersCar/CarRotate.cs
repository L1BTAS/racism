using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRotate : MonoBehaviour
{
    public float carRotate = 0f;

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (carRotate < 10)
            {
                transform.Rotate(0, 0, 1);
                carRotate++;
            }
                       
        }

        else if (Input.GetKey(KeyCode.D))
        {
            if(carRotate > -10)
            {
                transform.Rotate(0, 0, -1);
                carRotate--;
            }
            
        }

        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            
            if (carRotate > 0)
            {
                transform.Rotate(0, 0, -1);
                carRotate--;
            }
            else if (carRotate < 0)
            {
                transform.Rotate(0, 0, 1);
                carRotate++;
            }
        }

        else
        {
            if (carRotate > 0)
            {
                transform.Rotate(0, 0, -1);
                carRotate--;
            }
            else if (carRotate < 0)
            {
                transform.Rotate(0, 0, 1);
                carRotate++;
            }

        }
    }
}
