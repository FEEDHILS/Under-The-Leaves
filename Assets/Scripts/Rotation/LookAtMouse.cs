using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    Vector3 rotation = new Vector3();
    void Start()
    {
        rotation = transform.eulerAngles;
    }

    
    void FixedUpdate()
    {
        Vector3 dir = VecMousePoint.vector - transform.position;

        transform.eulerAngles = new Vector3(0 , rotation.y, MathThing(dir.normalized));
    }

    float MathThing(Vector2 _vec)
    {
        return Mathf.Atan2(_vec.y, _vec.x) * Mathf.Rad2Deg;
    }

    
}
