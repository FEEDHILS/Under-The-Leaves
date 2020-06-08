using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "New Loot Object", menuName = "Scriptable Object/Loot/New Loot Object")]
public class LootObject : ScriptableObject
{
    public Sprite Sprite;
    public string LootName;
    public bool CanHold;
    public GameObject Instance;
}
