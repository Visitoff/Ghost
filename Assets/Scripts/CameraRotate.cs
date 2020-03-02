using UnityEngine;

public class CameraRotate : MonoBehaviour
{

    Quaternion cameraRotation;
    float newXX, newYY, newZZ, newWW;
    float newX, newY, newZ, newW;
    float deltabc;
    float FirstQuaternion;
    float SecondlyQuaternion;

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
        cameraRotation.Set(newXX, newYY, newZZ, newWW);
        FirstQuaternion = Mathf.Abs(newXX) + Mathf.Abs(newYY) + Mathf.Abs(newZZ);
    }
    void Update()
    {
        truedelta();
        delta();
    }



    public void delta()
    {
        Quaternion cameraRotation = new Quaternion(
            Input.gyro.attitude.x * Time.deltaTime,
            Input.gyro.attitude.y * Time.deltaTime,
           -Input.gyro.attitude.z * Time.deltaTime,
           -Input.gyro.attitude.w * Time.deltaTime);

        cameraRotation.Set(newX, newY, newZ, newW);
        if (deltabc > 0.05f)
        {
            this.transform.localRotation = cameraRotation;
        }
        if (deltabc < 0.05f)
        {
            this.transform.localRotation = cameraRotation;
        }
    }
    void truedelta()
    {
        SecondlyQuaternion = (Mathf.Abs(newX) + Mathf.Abs(newY) + Mathf.Abs(newZ));
        float deltabc = SecondlyQuaternion - FirstQuaternion;
        if (deltabc > 0.05f)
        {
            SecondlyQuaternion = FirstQuaternion;
        }
    }
}