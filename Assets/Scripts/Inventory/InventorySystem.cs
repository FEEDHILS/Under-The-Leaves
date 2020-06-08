using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    HandCell HandCell;
    [SerializeField] int CellCount = 8;
    [SerializeField] GrabSystem grabSystem;
    List<Cell> Cells = new List<Cell>();
    void Start()
    {
        HandCell = new HandCell();
        for(int i = 0; i < CellCount; i++)
        {
            Cells.Add(new Cell());
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            print(HandCell.Name);
            foreach(Cell C in Cells)
            {
                print(C.Name);
            }
        }
    }

    public void AddToInventory(Loot _loot, GrabLoot instance)
    {
        LootObject loot = _loot.Settings;
        if(loot.CanHold && loot.Instance != null)
        {
            RemoveFromHandCell();
            AddToHandCell(loot, instance);
        }
        else
        {
            AddToCell(loot, instance);
        }
    }

    void AddToCell(LootObject loot, GrabLoot instance)
    {
        for(int i = 0; i < Cells.Count; i++)
        {
            if(Cells[i].Loot == null)
            {
                instance.DeleteTHIS();
                Cells[i].Setup(loot);
                Cells[i].AddLoot();
                return;
            }
        }
    }

    public void RemoveFromCell(int index)
    {
        if(Cells[index].Loot != null)
            grabSystem.Drop(Cells[index].Loot);
        
        Cells[index].Restart();
        Cells[index].RemoveLoot();
    }
    void AddToHandCell(LootObject loot, GrabLoot instance)
    {
        instance.DeleteTHIS();
        HandCell.Setup(loot);
        HandCell.AddLoot();
        grabSystem.Grab(HandCell.Loot);
    }

    public void RemoveFromHandCell()
    {
        if(HandCell.Loot != null)
            grabSystem.Drop(HandCell.Loot);
        
        HandCell.Restart();
        HandCell.RemoveLoot();
    }
}

public class Cell : MonoBehaviour
{
    public string Name {get; set; }

    public int Count = 0;
    public LootObject Loot {get; set; }

    public Cell()
    {
        Restart();
    }

    public void Restart()
    {
        Name = "None";
        Loot = null;
    }

    public void Setup(LootObject loot)
    {
        Loot = loot;
        Name = Loot.LootName;
    }
    public void AddLoot()
    {
        Count++;
    }
    public void RemoveLoot()
    {
        Count--;
    }

}

public class HandCell : Cell
{

    public HandCell()
    {
        Name = "None"; 
        Loot = null;
    }

}
