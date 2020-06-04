using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    Transform Player;
    [SerializeField] LayerMask CollisionMask;

    [Tooltip("CircleCast Circle radius")]
    [SerializeField] float CircleRadius;

    [Tooltip("The distance at which the object will be destroyed automatically")]
    [SerializeField] float DestroyDistance;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, CircleRadius);
    }

    
    void Update()
    {
        CollisionCheck();
        DistanceCheck();
    }

    void CollisionCheck()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, CircleRadius, Vector2.zero, CircleRadius, CollisionMask);
        if(hit.transform != null)
        {
            BulletDestroy();
        }

    }

    void DistanceCheck()
    {
        if(Vector2.Distance(Player.position, transform.position) > DestroyDistance)
        {
            BulletDestroy();
        }
    }

    void BulletDestroy()
    {
        Destroy(gameObject);
    }
}
