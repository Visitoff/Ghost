using UnityEngine;

public class CameraRotate : MonoBehaviour
{   
    void Start()
    {  
        if (Application.isMobilePlatform)
        {
            GameObject cameraParent = new GameObject("camParent");
            cameraParent.transform.position = this.transform.position;
            this.transform.parent = cameraParent.transform;
            cameraParent.transform.Rotate(Vector3.right, 90 * Time.deltaTime); 
        }
        Input.gyro.enabled = true;
    }

    void Update()
    {
        Quaternion cameraRotation = new Quaternion(Input.gyro.attitude.x, Input.gyro.attitude.y,
        -Input.gyro.attitude.z, -Input.gyro.attitude.w * Time.deltaTime);
        this.transform.localRotation = cameraRotation;
    }
}