using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicRotationCheck : MonoBehaviour
{
    RotationCheck check;
    void Start()
    {
        check = GetComponent<RotationCheck>();
    }


    void Update()
    {
        SpriteRenderer sp = GetComponent<SpriteRenderer>();
        
        bool value = check.value == 1 ? false : true;

        sp.flipY = value;
    }
}
