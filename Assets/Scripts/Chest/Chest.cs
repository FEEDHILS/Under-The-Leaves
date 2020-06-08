using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Chest : MonoBehaviour
{
    Transform player;
    [SerializeField] float maxDistance = 1f;
    [SerializeField] float delayBeforeDestroy = 1.2f;

    [SerializeField] UnityEvent OnChestOpen = new UnityEvent();

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    void Update()
    {
        if(Input.GetButtonDown("Use"))
        {
            if(Vector2.Distance(transform.position, player.position) < maxDistance)
            {
                OpenChest();
            }
        }
    }

    void OpenChest()
    {
        OnChestOpen.Invoke();
    }

    public void ChestDestroy()
    {
        Destroy(gameObject, delayBeforeDestroy);
    }
}
