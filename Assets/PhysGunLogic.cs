using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysGunLogic : MonoBehaviour
{
    bool isHolding;
    [SerializeField] float maxDist;
    GameObject childPoint;
    RaycastHit2D hit = new RaycastHit2D();

    [SerializeField] LayerMask mask = new LayerMask();
    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Cast();
        }
        else if(Input.GetMouseButtonUp(0))
        {
            isHolding = false;
            UnforceTheObject();
        }

    }

    void Cast()
    {
        if(!isHolding)
        {
            hit = Physics2D.Raycast(transform.position, transform.right, maxDist, mask);
        }

    
        if(hit.rigidbody != null && !isHolding)
        {
            isHolding = true;
        }

        if(isHolding)
        {
            hit.rigidbody.velocity = Vector2.zero;
            hit.transform.position = VecMousePoint.vector;
        }
    }

    void ForceTheObject(RaycastHit2D hit)
    {
        // GameObject point = new GameObject("Point");
        // childPoint = point;
        // point.transform.position = hit.transform.position;

        // point.transform.SetParent(transform);
    }

    void UnforceTheObject()
    {
        if(hit.rigidbody != null)
        {
            Destroy(childPoint);
            hit = new RaycastHit2D();
        }
    }
}
