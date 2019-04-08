using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollow : MonoBehaviour
{

    public GameObject cameraVirtual2;
    public GameObject cameraVirtual3;
    void Start()
    {
            cameraVirtual2.GetComponent<CinemachineVirtualCamera>().enabled=false;
            cameraVirtual3.GetComponent<CinemachineVirtualCamera>().enabled=false;
            
    }
    
     public void OnTriggerEnter(Collider collider)
    {

        if (collider.tag == "Camera2")
        {
            cameraVirtual2.GetComponent<CinemachineVirtualCamera>().enabled=true;
           
        }if (collider.tag == "Camera3")
        {
            cameraVirtual3.GetComponent<CinemachineVirtualCamera>().enabled=true;
            cameraVirtual2.GetComponent<CinemachineVirtualCamera>().enabled=false;
           
        }
    }  
    public void OnTriggerExit(Collider collider)
    {

        if (collider.tag == "Camera2")
        {
            cameraVirtual2.GetComponent<CinemachineVirtualCamera>().enabled=false;
           
        }
        if (collider.tag == "Camera3")
        {
            cameraVirtual3.GetComponent<CinemachineVirtualCamera>().enabled=false;
           
        }

    }  
}

