using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotationCorrection : RotationCheck
{
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("PlyGraphics").transform;
    }
    void Update()
    {
        int value = Check();

         Vector3 rotation = transform.rotation.eulerAngles;
        if(value == -1)
             transform.localRotation = Quaternion.AngleAxis(180, Vector3.right);
        else if(value == 1)
            transform.localRotation = Quaternion.AngleAxis(0, Vector3.right); 
    }
}
