using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventorySaveData
{
    public int coins;
    public List<string> itemIDs = new List<string>();
    public List<int> itemQuantities = new List<int>();

    public InventorySaveData(InventorySystem inventory)
    {
        coins = inventory.GetCoins();
        foreach (var kvp in inventory.GetInventory())
        {
            itemIDs.Add(kvp.Key);
            itemQuantities.Add(kvp.Value.quantity);
        }
    }
}