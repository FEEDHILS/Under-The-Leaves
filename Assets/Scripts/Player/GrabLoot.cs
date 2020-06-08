using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GrabLoot : MonoBehaviour
{
    [SerializeField] float maxDist;
    Transform Player;

    Loot loot;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        loot = GetComponent<Loot>();
    }


    void Update()
    {
        if(Input.GetButtonDown("Use") && Player != null)
        {
            if(Vector2.Distance(transform.position, Player.position) < maxDist)
            {
                Grab();
            }
        }
    }

    void Grab()
    {
        GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventorySystem>().AddToInventory(loot, this);
    }

    public void DeleteTHIS()
    {
        Destroy(gameObject);
    }
}
