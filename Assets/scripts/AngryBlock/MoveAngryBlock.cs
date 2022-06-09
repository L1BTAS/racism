using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAngryBlock : MonoBehaviour
{
    public float Speed = 1f;
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
    float score;
    int scoreINT;
    int GetScore;
    float a;
    [SerializeField] private float  Deceleration=5;
=======
>>>>>>> parent of fcb2714 (я скор сделал)
=======
>>>>>>> parent of fcb2714 (я скор сделал)
=======
>>>>>>> parent of fcb2714 (я скор сделал)
=======
>>>>>>> parent of fcb2714 (я скор сделал)
    private Rigidbody2D rb;
    void Update()
    {
        score = Time.time;
        scoreINT = ((int)score);
        GetScore = SpeedUp(scoreINT);

        rb = GetComponent<Rigidbody2D>();
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        a = -Speed - GetScore - Time.timeSinceLevelLoad / Deceleration ;
        rb.velocity = new Vector2(0, a);
        
       
=======
        rb.velocity = new Vector2(0, -Speed - Time.timeSinceLevelLoad / 5);
        //print(-Speed - Time.timeSinceLevelLoad / 5);
>>>>>>> parent of fcb2714 (я скор сделал)
    }
   int SpeedUp(float scoreINT)
    {
        if(scoreINT >=40)
        {
            return 20;
        }
        return 0;
=======
        rb.velocity = new Vector2(0, -Speed - Time.timeSinceLevelLoad / 5);
        //print(-Speed - Time.timeSinceLevelLoad / 5);
>>>>>>> parent of fcb2714 (я скор сделал)
=======
        rb.velocity = new Vector2(0, -Speed - Time.timeSinceLevelLoad / 5);
        //print(-Speed - Time.timeSinceLevelLoad / 5);
>>>>>>> parent of fcb2714 (я скор сделал)
=======
        rb.velocity = new Vector2(0, -Speed - Time.timeSinceLevelLoad / 5);
        //print(-Speed - Time.timeSinceLevelLoad / 5);
>>>>>>> parent of fcb2714 (я скор сделал)
    }
}
