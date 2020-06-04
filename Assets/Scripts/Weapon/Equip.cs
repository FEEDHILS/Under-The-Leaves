using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Equip : MonoBehaviour
{
    Transform PivotPoint;
    StateController states;
    Transform Player;
    [SerializeField] float ThrowPower = 1.2f;
    [SerializeField] float MaxDist = 1.2f;
    Rigidbody2D rb;

    public UnityEvent OnPickUp = new UnityEvent();
    public UnityEvent OnDrop = new UnityEvent();
    
    void Awake()
    {
        PivotPoint = GameObject.FindGameObjectWithTag("GunPivot").transform;
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        states = GetComponent<StateController>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        CheckState();
    }

    
    void Update()
    {
        if(Input.GetButtonDown("Equip") && Vector3.Distance(transform.position, Player.position ) <= MaxDist)
        {
            states.Set("Equiped");
            CheckState();
        }
        else if(Input.GetButtonDown("Drop"))
        {
            states.Set("World");
            CheckState();
        }
    }

    void CheckState()
    {
        if(states.Get() == "Equiped")
        {
            transform.SetParent(PivotPoint);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;

            OnPickUp.Invoke();
        
        }

        if(states.Get() == "World")
        {
            Transform _parent = transform.parent;
            transform.SetParent(null);

            OnDrop.Invoke();
            if(_parent != null)
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(_parent.right * ThrowPower, ForceMode2D.Impulse);
            }
                

        }
        
    }
}
