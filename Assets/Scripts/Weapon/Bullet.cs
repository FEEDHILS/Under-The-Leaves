using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : EntityMovement
{
    void Awake()
    {
        Hor = Vector2.right.normalized;
    }
    
    void Update()
    {
        Move();
    }
}
