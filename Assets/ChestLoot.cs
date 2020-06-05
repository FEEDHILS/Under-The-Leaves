using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChestLoot : MonoBehaviour
{
    [SerializeField] List<GameObject> Loot = new List<GameObject>();
    [SerializeField] float forceStrength = 2.5f;
    [SerializeField] int angleScatter = 45;

    [SerializeField] UnityEvent OnAllLootDroped = new UnityEvent();

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void ThrowLoot()
    {
        Vector2 spawnPosition = new Vector2(transform.position.x, transform.position.y + 0.8f);

        foreach(GameObject lootObject in Loot)
        {
            int randomAngle =  Random.Range(-(angleScatter / 2), angleScatter / 2);
            Quaternion rotation = Quaternion.AngleAxis(randomAngle, Vector3.forward);

            GameObject currentLoot = Instantiate(lootObject, spawnPosition, rotation) as GameObject;

            currentLoot.GetComponent<Rigidbody2D>()?.AddForce(currentLoot.transform.up * forceStrength, ForceMode2D.Impulse);
        }

        OnAllLootDroped.Invoke();
    }
}
