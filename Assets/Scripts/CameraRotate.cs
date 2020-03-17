using UnityEngine;

public class CameraRotate : MonoBehaviour
{

    Quaternion cameraRotation;
    float quanternionDelta;
    float FirstQuaternionValue;
    float ValueOfInputX, ValueOfInputY, ValueOfInputZ, ValueOfInputW;
    float StartValueOfInputX, StartValueOfInputY, StartValueOfInputZ, StartValueOfInputW;




    void Start()
    {
        //  if (Application.isMobilePlatform)
        //  {
        // GameObject cameraParent = new GameObject("camParent");
        //cameraParent.transform.position = transform.position;
        //this.transform.parent = cameraParent.transform;
        this.transform.Rotate(Vector3.right, 90);
        //}
        Input.gyro.enabled = true;
        StartValueOfInputX = Input.gyro.attitude.x * Time.deltaTime;
        StartValueOfInputY = Input.gyro.attitude.y * Time.deltaTime;
        StartValueOfInputZ = -Input.gyro.attitude.z * Time.deltaTime;
        StartValueOfInputW = -Input.gyro.attitude.w * Time.deltaTime;
        FirstQuaternionValue = Mathf.Abs(0) + Mathf.Abs(0) + Mathf.Abs(0) + Mathf.Abs(0);
    }
    void Update()
    {
        InputSystem();
        QuanternionDelta();

    }



    public void InputSystem()
    {
        ValueOfInputX = Input.gyro.attitude.x * Time.deltaTime;
        ValueOfInputY = Input.gyro.attitude.y * Time.deltaTime;
        ValueOfInputZ = -Input.gyro.attitude.z * Time.deltaTime;
        ValueOfInputW = -Input.gyro.attitude.w * Time.deltaTime;

        cameraRotation = new Quaternion(
          0,
          0,
          0,
          0);
}
    void QuanternionDelta()
    {
        float SecondlyQuaternionValue = Mathf.Abs(ValueOfInputX) + Mathf.Abs(ValueOfInputY) + Mathf.Abs(ValueOfInputZ) + Mathf.Abs(ValueOfInputW);
        quanternionDelta = SecondlyQuaternionValue - FirstQuaternionValue;
        Debug.Log(quanternionDelta);
        if (quanternionDelta > 100f)
        {
            FirstQuaternionValue = SecondlyQuaternionValue;
            this.transform.localRotation = cameraRotation;
        }
    }
}
