using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCheck : MonoBehaviour
{
    public Transform target;
    public int value = 0;

    void Update()
    {
        Check();
    }

    void Check()
    {
        if(target.right == Vector3.right)
        {
            value = 1;
        }
        else if(target.right == Vector3.left)
        {
            value = -1;
        }

        
        
    }
}
