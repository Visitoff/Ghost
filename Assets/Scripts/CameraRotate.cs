using UnityEngine;

public class CameraRotate : MonoBehaviour
{

    Quaternion cameraRotation;
    float deltabc;
    float FirstQuaternionValue;
    float ValueOfInputX, ValueOfInputY, ValueOfInputZ, ValueOfInputW;
    float StartValueOfInputX, StartValueOfInputY, StartValueOfInputZ, StartValueOfInputW;




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
        StartValueOfInputX = Input.gyro.attitude.x * Time.deltaTime;
        StartValueOfInputY = Input.gyro.attitude.y * Time.deltaTime;
        StartValueOfInputZ = -Input.gyro.attitude.z * Time.deltaTime;
        StartValueOfInputW = -Input.gyro.attitude.w * Time.deltaTime;
        FirstQuaternionValue = Mathf.Abs(StartValueOfInputX) + Mathf.Abs(StartValueOfInputY) + Mathf.Abs(StartValueOfInputZ) + Mathf.Abs(StartValueOfInputW);
    }
    void Update()
    {
        InputSystem();
        QuanternionDelta(); 
    }



    public void InputSystem()
    {
        cameraRotation = new Quaternion(
          ValueOfInputX,
          ValueOfInputY,
          ValueOfInputZ,
          ValueOfInputW);


        ValueOfInputX = Input.gyro.attitude.x * Time.deltaTime;
        ValueOfInputY = Input.gyro.attitude.y * Time.deltaTime;
        ValueOfInputZ = -Input.gyro.attitude.z * Time.deltaTime;
        ValueOfInputW = -Input.gyro.attitude.w * Time.deltaTime;
        this.transform.localRotation = cameraRotation;
    }
    void QuanternionDelta()
    {
        float SecondlyQuaternionValue = Mathf.Abs(ValueOfInputX) + Mathf.Abs(ValueOfInputY) + Mathf.Abs(ValueOfInputZ) + Mathf.Abs(ValueOfInputW);
        deltabc = SecondlyQuaternionValue - FirstQuaternionValue;
        if (deltabc > 0.05f)
        {
            SecondlyQuaternionValue = FirstQuaternionValue;
            this.transform.localRotation = cameraRotation;
        }
    }
    
}