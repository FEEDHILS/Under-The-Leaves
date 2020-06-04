using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    Vector3 _right;
    void Start()
    {
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
            transform.right = _right;
        }
        else if(mousePos.x < value.x)
        {
            transform.right = -_right;
        }
    }
}
