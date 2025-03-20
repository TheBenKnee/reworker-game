using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryItem
{
    public ItemData item;
    public int quantity;

    public InventoryItem(ItemData item, int quantity)
    {
        this.item = item;
        this.quantity = quantity;
    }
}
