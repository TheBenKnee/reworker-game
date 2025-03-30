using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class InventorySaveSystem
{
    private static string SavePath => Path.Combine(Application.persistentDataPath, "inventory_save.json");

    public static void SaveInventory(InventorySystem inventory)
    {
        InventorySaveData saveData = new InventorySaveData(inventory);
        string json = JsonUtility.ToJson(saveData, true);
        File.WriteAllText(SavePath, json);
        Debug.Log("Inventory saved!");
    }

    public static void LoadInventory(InventorySystem inventory)
    {
        if (!File.Exists(SavePath))
        {
            Debug.LogWarning("No save file found!");
            return;
        }

        string json = File.ReadAllText(SavePath);
        InventorySaveData saveData = JsonUtility.FromJson<InventorySaveData>(json);

        inventory.AddCoins(saveData.coins);

        foreach (var itemID in saveData.itemIDs)
        {
            if (ItemDatabase.GetItemDatabase().TryGetValue(itemID, out ItemData item))
            {
                int index = saveData.itemIDs.IndexOf(itemID);
                inventory.AddItem(item, saveData.itemQuantities[index]);
            }
        }

        Debug.Log("Inventory loaded!");
    }
}
