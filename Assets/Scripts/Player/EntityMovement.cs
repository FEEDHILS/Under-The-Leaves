using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    public Vector2 Hor { get; set; }

    public float MoveSpeed;

    public void Move()
    {
        transform.Translate(Hor * MoveSpeed * Time.deltaTime);
    }
}
