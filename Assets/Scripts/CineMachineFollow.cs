using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CineMachineFollow : MonoBehaviour
{
    public GameObject tPlayer;
    public Transform tFollowTarget;
    private CinemachineVirtualCamera vCam;
    void Awake()
    {
        vCam = GetComponent<CinemachineVirtualCamera>();
    }
    void Update()
    {
        if(tPlayer == null)
        {
            tPlayer = GameObject.FindWithTag("Player");
            if(tPlayer != null)
            {
                tFollowTarget = tPlayer.transform;
                vCam.LookAt = tFollowTarget;
                vCam.Follow = tFollowTarget;
            }
        }
    }
}
