﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArCam : MonoBehaviour
{
    public GameObject PlaneObject;

    void Start()
    {
        
        if (Application.isMobilePlatform)
        {
            GameObject cameraParent = new GameObject("camParent");
            cameraParent.transform.position = this.transform.position;
            this.transform.parent = cameraParent.transform;
            cameraParent.transform.Rotate(Vector3.right, 90); //This is for rotation of camera.
        }


        Input.gyro.enabled = true; 

        WebCamTexture webCameraTexture = new WebCamTexture();
        PlaneObject.GetComponent<MeshRenderer>().material.mainTexture = webCameraTexture;
        webCameraTexture.Play();
    }

   

    void Update()
    {
        
        Quaternion cameraRotation = new Quaternion(Input.gyro.attitude.x, Input.gyro.attitude.y,
            -Input.gyro.attitude.z, -Input.gyro.attitude.w);
        this.transform.localRotation = cameraRotation;      
    }
}
