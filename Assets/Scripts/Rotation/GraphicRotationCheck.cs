using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicRotationCheck : MonoBehaviour
{
    RotationCheck check;
    void Start()
    {
        check = GetComponent<RotationCheck>();
    }


    void Update()
    {
        
        int value = check.value == 1 ? 0 : 180;

        transform.eulerAngles = new Vector3(value, 0, 0);
    }
}
