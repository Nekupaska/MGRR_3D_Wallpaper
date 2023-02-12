using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWind : MonoBehaviour
{
    WindZone wz;
    public float a = -25f, b = -60f;

    void Start()
    {
        wz = GetComponent<WindZone>();
        InvokeRepeating("RotateAngleBetweenRange", 3, 3);
    }

    Quaternion newRot = new Quaternion();
    Vector3 angles = new Vector3();
    void RotateAngleBetweenRange()
    {
        float newAngle = Random.Range(a, b);
        angles.x = newAngle;
        angles.y = transform.rotation.eulerAngles.y;
        angles.z = transform.rotation.eulerAngles.z;
        newRot.eulerAngles = angles;
        transform.rotation = newRot;
    }
}
