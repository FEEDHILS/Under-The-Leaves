using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GrabSystem : MonoBehaviour
{
    [SerializeField] GameObject LootBlank;
    [SerializeField] Transform PivotPoint;
    GameObject InHand;

    public UnityEvent OnDrop;
    public UnityEvent DropItem;
    void Start()
    {
        
    }


    void Update()
    {
        if(Input.GetButtonDown("Drop"))
        {
            OnDrop.Invoke();
        }
        if(Input.GetKeyDown(KeyCode.V))
        {
            DropItem.Invoke();
        }
    }

    public void Grab(LootObject _loot)
    {
        InHand = Instantiate(_loot.Instance, transform.position, Quaternion.identity);
        InHand.transform.SetParent(PivotPoint);
        InHand.transform.localPosition = Vector3.zero;
        InHand.transform.localRotation = Quaternion.identity;
        InHand.GetComponent<Equip>().OnEquiped();
    }

    public void Drop(LootObject _loot)
    {
        GameObject loot = Instantiate(LootBlank, transform.position, Quaternion.identity);
        if(_loot.CanHold)
            Destroy(InHand);
        
        loot.GetComponent<Loot>().Settings = _loot;   
    }
}
