using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour
{
    [SerializeField] float JumpStrength;
    [SerializeField] Rigidbody2D rb = new Rigidbody2D();

    public bool CanJump = false;

    
    void Update()
    {
        Jumping();

    }

    void Jumping()
    {
        if(Input.GetButtonDown("Jump") && CanJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(transform.up.normalized * JumpStrength, ForceMode2D.Impulse);
        }
    }
}
