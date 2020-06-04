using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollision : MonoBehaviour
{
    [SerializeField] float Radius;
    
    CharacterJump _jump;
    [SerializeField] LayerMask mask;

    void Start()
    {
        _jump = transform.parent.GetComponent<CharacterJump>();
    }
    
    void FixedUpdate()
    {

        RaycastHit2D hit = Physics2D.CircleCast(transform.position, Radius, Vector2.down, Radius, mask);

        if(hit.transform != null)
        {
            _jump.CanJump = true;
        }
        else
        {
            _jump.CanJump = false;
        }
    }
}
