using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocus : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] bool Smooth = true;
    
    [SerializeField] Transform target;
    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        Focus();
    }

    void Focus()
    {
        Vector3 _target = target.position;
        _target.z = transform.position.z;
        transform.position = Vector3.Lerp(transform.position, _target, Time.deltaTime * Speed);
    }
}
