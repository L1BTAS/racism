using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour
{
    float score = 0;
    int scoreINT = 0;
    [SerializeField] Text scoreText;
    
    void FixedUpdate()
    {

        score = Time.time;
        scoreINT=((int)score);
        scoreText.text = scoreINT.ToString();
    }
    
    
}
