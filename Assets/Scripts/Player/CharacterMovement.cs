using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : EntityMovement
{  
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Hor = Vector2.right * Input.GetAxis("Horizontal") * transform.right.normalized.x;
        Move();
    }

}
