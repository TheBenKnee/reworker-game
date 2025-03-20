using System;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem
{
    private Dictionary<string, InventoryItem> items = new Dictionary<string, InventoryItem>();
    private int coins = 0;

    public void AddItem(ItemData item, int quantity)
    {
        if (items.ContainsKey(item.itemID))
        {
            items[item.itemID].quantity += quantity;
        }
        else
        {
            items[item.itemID] = new InventoryItem(item, quantity);
        }
    }

    public void RemoveItem(string itemID, int quantity)
    {
        if (items.ContainsKey(itemID))
        {
            items[itemID].quantity -= quantity;
            if (items[itemID].quantity <= 0)
            {
                items.Remove(itemID);
            }
        }
    }

    public void UseItem(string itemID, PlayerManager player)
    {
        if (items.ContainsKey(itemID))
        {
            InventoryItem invItem = items[itemID];
            
            if (invItem.item is IUsable usableItem)
            {
                usableItem.Use(player);
                if(invItem.item.itemType == ItemData.ItemType.Consumable)
                {
                    RemoveItem(itemID, 1);
                }
            }
            else
            {
                Debug.Log($"{invItem.item.name} is not usable.");
            }
        }
        else
        {
            Debug.Log("Item not found in inventory.");
        }
    }

    public bool HasItem(string itemID, int quantity)
    {
        return items.ContainsKey(itemID) && items[itemID].quantity >= quantity;
    }

    public void AddCoins(int additionalCoins)
    {
        coins += additionalCoins;
    }

    public bool RemoveCoins(int reductionCoins)
    {
        if(coins >= reductionCoins)
        {
            coins -= reductionCoins;
            return true;
        }
        return false;
    }

    public bool CanAfford(int price)
    {
        return coins >= price;
    }

    public int GetCoins() => coins;
    public Dictionary<string, InventoryItem> GetInventory() => items;
}
