using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPotion : ItemData, IUsable
{
    public int manaAmount = 10;

    public override void Use(PlayerManager player)
    {
        player.RestoreMana(manaAmount);
        Debug.Log($"{name} used. restored {manaAmount} MP.");
    }

    public ManaPotion(string itemID, string name, string description, int maxStack, ItemType itemType, int manaAmount) : base(itemID, name, description, maxStack, itemType)
    {
        this.manaAmount = manaAmount;
    }
}