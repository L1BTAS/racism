using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FollowPlayer : MonoBehaviour
{
    private CinemachineVirtualCamera vcam;

    void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player0") != null)
        {
            vcam.Follow = GameObject.FindGameObjectWithTag("Player0").transform;
            vcam.LookAt = GameObject.FindGameObjectWithTag("Player0").transform;
        }
        
    }
}
