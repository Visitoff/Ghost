using UnityEngine;

public class CameraRotate : MonoBehaviour
{

    Quaternion cameraRotation;
    float X, Y, Z;
    float newX, newY, newZ;
    float deltabc;
    float FirstQuaternionValue;


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
        cameraRotation = Quaternion.Euler(X, Y, Z);
        FirstQuaternionValue = Mathf.Abs(X) + Mathf.Abs(Y) + Mathf.Abs(Z);
    }
    void Update()
    {
        IfNeedTransform();
        QuanternionDelta();
    }



    public void IfNeedTransform()
    {
        cameraRotation = new Quaternion(
           Input.gyro.attitude.x * Time.deltaTime,
           Input.gyro.attitude.y * Time.deltaTime,
          -Input.gyro.attitude.z * Time.deltaTime,
          -Input.gyro.attitude.w * Time.deltaTime);

        cameraRotation = Quaternion.Euler(newX, newY, newZ);
        if (deltabc > 0.05f)
        {
            this.transform.localRotation = cameraRotation;
        }
    }
    void QuanternionDelta()
    {
        float SecondlyQuaternionValue = (Mathf.Abs(newX) + Mathf.Abs(newY) + Mathf.Abs(newZ));
        float deltabc = SecondlyQuaternionValue - FirstQuaternionValue;
        if (deltabc > 0.05f)
        {
            SecondlyQuaternionValue = FirstQuaternionValue;
        }
    }
}