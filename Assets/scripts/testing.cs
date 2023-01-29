using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testing : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        FunctionTimer.Create(TestingAction, 3f); 
    }

    // Update is called once per frame
    private void TestingAction()
    {
        Debug.Log("Testing!!!!");
    }
}
