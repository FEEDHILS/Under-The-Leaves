using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    Vector3 _right;
    Vector2 _up;
    void Start()
    {
        _up = new Vector2(transform.up.x, transform.up.y);
        _right = transform.right;
    }

    
    void Update()
    {
        GoFlip();
    }

    void GoFlip()
    {
        Vector2 mousePos = Camera.main.WorldToViewportPoint(VecMousePoint.vector);

        Vector2 value = Camera.main.WorldToViewportPoint(transform.position);

        if(mousePos.x > value.x)
        {
            transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
        }
        else if(mousePos.x < value.x)
        {
            transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
        }
    }
}
