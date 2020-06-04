using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject Bullet;
    [SerializeField] Transform FireSpot;
    [SerializeField] float FireDelay = 0.5f;

    bool CanShoot = true;
    StateController states;

    void Start()
    {
        states = GetComponent<StateController>();
    }

    
    void Update()
    {
        if(states.Get() == "Equiped")
        {
            if(Input.GetMouseButtonDown(0) && CanShoot)
            {
                StartCoroutine("Shoot");
            }
        }
    }

    IEnumerator Shoot()
    {
        CanShoot = false;
        Instantiate(Bullet, FireSpot.position, FireSpot.rotation);
        yield return new WaitForSeconds(FireDelay);
        CanShoot = true;  
    }
}
