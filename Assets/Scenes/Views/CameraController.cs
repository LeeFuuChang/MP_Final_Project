using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    private const float slerpFactor = 0.5f;
    private void Start()
    {
        Input.gyro.enabled = true;
        Input.gyro.updateInterval = 0.05f;
    }
    private void Update()
    {
        if (Input.gyro.enabled)
        {
            target.transform.rotation = Quaternion.Slerp(target.transform.rotation, ConvertRotation(Input.gyro.attitude), slerpFactor);
        }
    }
    private Quaternion ConvertRotation(Quaternion q)
    {
        return Quaternion.Euler(90, 0, 0) * new Quaternion(-q.x, -q.y, q.z, q.w);
    }
}
