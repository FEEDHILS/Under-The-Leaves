using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    public LootObject Settings;
    SpriteRenderer spr = new SpriteRenderer();
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();

        spr.sprite = Settings.Sprite;
        gameObject.name = Settings.LootName;
    }
}
