using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ArmorData : ItemData
{
    public int defense;
    public int durability;

    public ArmorData(string itemID, string name, string description, int maxStack, ItemType itemType, int defense, int durability) : base(itemID, name, description, maxStack, itemType)
    {
        this.defense = defense;
        this.durability = durability;
    }
}