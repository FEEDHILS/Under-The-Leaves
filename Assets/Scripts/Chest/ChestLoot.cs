using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChestLoot : MonoBehaviour
{
    [SerializeField] GameObject LootBlank;
    [SerializeField] List<LootObject> Loot = new List<LootObject>();
    [SerializeField] float forceStrength = 2.5f;
    [SerializeField] int angleScatter = 45;

    [SerializeField] UnityEvent OnAllLootDroped = new UnityEvent();

    [SerializeField] bool CanDropLoot = true;

    public void ThrowLoot()
    {
        if(!CanDropLoot)
            return;
        

        Vector2 spawnPosition = new Vector2(transform.position.x, transform.position.y + 0.8f);

        foreach(LootObject lootObject in Loot)
        {
            int randomAngle =  Random.Range(-(angleScatter / 2), angleScatter / 2);
            Quaternion rotation = Quaternion.AngleAxis(randomAngle, Vector3.forward);

            GameObject currentLoot = Instantiate(LootBlank, spawnPosition, rotation) as GameObject;

            currentLoot.GetComponent<Loot>().Settings = lootObject;
            currentLoot.GetComponent<Rigidbody2D>()?.AddForce(currentLoot.transform.up * forceStrength, ForceMode2D.Impulse);
        }
        
        CanDropLoot = false;
        OnAllLootDroped.Invoke();
    }
}
