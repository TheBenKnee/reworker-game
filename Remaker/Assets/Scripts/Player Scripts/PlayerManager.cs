using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerAmmo playerAmmo;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private PlayerMana playerMana;
    [SerializeField] private PlayerMovement playerMovement;
    private InventorySystem inventorySystem = new InventorySystem();

    [ContextMenu("Debug Add Items")]
    public void AddItems()
    {
        AddItem(ItemDatabase.GetItem("bunny"), 1);
        AddItem(ItemDatabase.GetItem("basic_sword"), 1);
    }

    // Linker functions for Inventory

    public InventorySystem GetInventorySystem()
    {
        return inventorySystem;
    }

    public Dictionary<string, InventoryItem> GetInventory()
    {
        return inventorySystem.GetInventory();
    }

    [ContextMenu("Print Inventory")]
    public void PrintInventory()
    {
        foreach(KeyValuePair<string, InventoryItem> kvp in inventorySystem.GetInventory())
        {
            Debug.Log($"{kvp.Value.quantity} '{kvp.Key}'s");
        }
    }

    public void AddItem(ItemData item, int quantity)
    {
        inventorySystem.AddItem(item, quantity);
    }

    public void UseItem(string itemID)
    {
        inventorySystem.UseItem(itemID, this); 
    }

    // Linker functions for Player Health

    public void Heal(int amount)
    {
        playerHealth.Heal(amount);
    }

    // Linker functions for Player Mana

    public void RestoreMana(int amount)
    {
        playerMana.RestoreMana(amount);
    }
}
