using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Equip : MonoBehaviour
{
    public UnityEvent OnPickUp = new UnityEvent();


    public void OnEquiped()
    {
        OnPickUp.Invoke();
    }
}
