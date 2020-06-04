using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        Vector3 dir = VecMousePoint.vector - transform.position;

        transform.eulerAngles = new Vector3(0, 0, MathThing(dir.normalized));
        
    }

    float MathThing(Vector2 _vec)
    {
        return Mathf.Atan2(_vec.y, _vec.x) * Mathf.Rad2Deg;
    }

    
}
