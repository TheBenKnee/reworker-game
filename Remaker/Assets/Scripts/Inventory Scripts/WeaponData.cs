using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WeaponData : ItemData
{
    public int damage;
    public float attackSpeed;
    public int durability;

    public WeaponData(string itemID, string name, string description, int maxStack, ItemType itemType, int damage, float attackSpeed, int durability) : base(itemID, name, description, maxStack, itemType)
    {
        this.damage = damage;
        this.attackSpeed = attackSpeed;
        this.durability = durability;
    }
}
