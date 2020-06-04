using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VecMousePoint : MonoBehaviour
{ 
    public static Vector3 vector;

    void Awake()
    {

    }
    void Update()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.z = 0;
        vector = mousePos;
    }
}
