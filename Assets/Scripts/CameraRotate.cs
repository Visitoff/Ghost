using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    float clampDistance = Screen.width * 0.05f;
    void Start()
    {
        if (Application.isMobilePlatform)
        {
            GameObject cameraParent = new GameObject("camParent");
            cameraParent.transform.position = this.transform.position;
            this.transform.parent = cameraParent.transform;
            cameraParent.transform.Rotate(Vector3.right, 90);
        }
        Input.gyro.enabled = true;
    }

    void Update()
    {
        Quaternion zeroZone = new Quaternion(0f, 0f, 0f, 0f);
        Quaternion cameraRotation = new Quaternion(Input.gyro.attitude.x * Time.deltaTime, Input.gyro.attitude.y * Time.deltaTime,
        -Input.gyro.attitude.z * Time.deltaTime, -Input.gyro.attitude.w * Time.deltaTime);
        this.transform.localRotation = cameraRotation;
        Debug.Log(cameraRotation);
        if (cameraRotation = 0f) 
        {

        }
        Quaternion cameraRotation { get; }

    }
}
    
 
