using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLocalSelf : MonoBehaviour
{
    public float speed = -50;
    void Update()
    {
        transform.RotateAround(transform.position, transform.forward, Time.deltaTime * speed);
    }
}
