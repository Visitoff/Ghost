using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    float lastValue;
    private float nemX;
    private float nemY;
    private float nemZ;
    private float nemW;
    

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
    public void delta()
    {
        float deltaValue = (nemX + nemY + nemZ + nemW) - lastValue;
        lastValue = (nemX + nemY + nemZ + nemW);
        if (deltaValue > 0.05f)
        {
            Quaternion cameraRotation = new Quaternion(Input.gyro.attitude.x * Time.deltaTime, Input.gyro.attitude.y * Time.deltaTime,
            -Input.gyro.attitude.z * Time.deltaTime, -Input.gyro.attitude.w * Time.deltaTime);
            cameraRotation.Set(nemX, nemY, nemZ, nemW);
            this.transform.localRotation = cameraRotation;
        }
    }
    void Update()
    {
        delta();
    }
}