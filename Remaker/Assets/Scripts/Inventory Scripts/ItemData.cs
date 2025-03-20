using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemData
{
    public string itemID;
    public string name;
    public string description;
    public int maxStack;
    public ItemType itemType;
    public Sprite sprite;

    public enum ItemType
    {
        Default,
        Consumable,
        Usable,
        Weapon,
        Armor
    }

    public virtual void Use(PlayerManager player)
    {
        Debug.Log($"{name} has no effect.");
    }

    public ItemData(string itemID, string name, string description, int maxStack, ItemType itemType)
    {
        this.itemID = itemID;
        this.name = name;
        this.description = description;
        this.maxStack = maxStack;
        this.itemType = itemType;
    } 
}
