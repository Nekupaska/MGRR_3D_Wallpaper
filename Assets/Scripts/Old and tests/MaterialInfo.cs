using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialInfo : MonoBehaviour
{
    Renderer r;
    void Start()
    {
        r = GetComponent<Renderer>();
    }


    void Update()
    {
        //print(r.material.color);
    }
}
