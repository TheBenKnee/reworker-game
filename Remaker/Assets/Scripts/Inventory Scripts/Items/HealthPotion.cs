using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : ItemData, IUsable
{
    public int healAmount = 20;

    public override void Use(PlayerManager player)
    {
        player.Heal(healAmount);
        Debug.Log($"{name} used. restored {healAmount} HP.");
    }

    public HealthPotion(string itemID, string name, string description, int maxStack, ItemType itemType, int healAmount) : base(itemID, name, description, maxStack, itemType)
    {
        this.healAmount = healAmount;
    }
}
