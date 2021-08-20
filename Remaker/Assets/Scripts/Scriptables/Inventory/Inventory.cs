using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Player Inventory", fileName = "New Player Inventory")]
public class Inventory : ScriptableObject
{
    public List<int> myInventory = new List<int>();
    public List<InventoryItem> itemList = new List<InventoryItem>();
    public int coins;

    //public void AddItemNum(int )

    public void AddItem(InventoryItem newItem)
    {
        // if (!myInventory.Contains(newItem))
        // {
        //     myInventory.Add(newItem);
        // }
        // else
        // {
        //     newItem.numberHeld++;
        // }
        for(int i = 0; i < itemList.Count; i++)
        {
            if(newItem.idNum == itemList[i].idNum)
            {
                itemList[i].numberHeld++;
            }
        }
        Debug.Log("Failed to add item with Id # " + newItem.idNum);
    }

    public void RemoveItem(InventoryItem newItem)
    {
        if (myInventory.Contains(newItem.idNum))
        {
            myInventory.Remove(newItem.idNum);
        }
    }

    public void UseItem(InventoryItem newItem)
    {
        if (myInventory.Contains(newItem.idNum))
        {
            if (getItem(newItem.idNum).numberHeld > 0)
            {
                getItem(newItem.idNum).numberHeld--;
            }
        }
    }

    public bool IsItemInInventory(int newItem)
    {
        return myInventory.Contains(newItem);
    }

    public bool canUseItem(int newItem)
    {
        return getItem(newItem).numberHeld > 0;
    }

    public void AddCoins(int coinsToAdd)
    {
        coins += coinsToAdd;
    }

    public void SubtractCoins(int coinsToSubtract)
    {
        coins -= coinsToSubtract;
    }

    public InventoryItem getItem(int itemId)
    {
        for(int i = 0; i < itemList.Count; i++)
        {
            if(itemId == itemList[i].idNum)
            {
                return(itemList[i]);
            }
        }
        Debug.Log("Item with Id # " + itemId + " not found.");
        return null;
    }
}