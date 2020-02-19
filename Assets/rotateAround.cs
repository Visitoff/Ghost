using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateAround : MonoBehaviour
{
    public GameObject self;
    public float _speed;

    // Update is called once per frame
    void Update()
    {
        self.transform.Rotate(Vector3.up * _speed * Time.deltaTime);
    }
}
