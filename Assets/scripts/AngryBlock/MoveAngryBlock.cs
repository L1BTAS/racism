using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAngryBlock : MonoBehaviour
{
    public float Speed = 1f;
    float score;
    int scoreINT;
    int GetScore;
    float a;
    [SerializeField] private float  Deceleration=5;
    private Rigidbody2D rb;
    void Update()
    {
        score = Time.time;
        scoreINT = ((int)score);
        GetScore = SpeedUp(scoreINT);

        rb = GetComponent<Rigidbody2D>();
        a = -Speed - GetScore - Time.timeSinceLevelLoad / Deceleration ;
        rb.velocity = new Vector2(0, a);
        
       
    }
   int SpeedUp(float scoreINT)
    {
        if(scoreINT >=40)
        {
            return 20;
        }
        return 0;
    }
}
