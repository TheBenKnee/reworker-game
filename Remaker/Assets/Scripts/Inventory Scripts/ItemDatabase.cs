using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ItemDatabase
{
    public static Dictionary<string, ItemData> GetItemDatabase() => itemDictionary;
    private static Dictionary<string, ItemData> itemDictionary = new Dictionary<string, ItemData>{
        {"bunny", new ItemData("bunny", "Bunny", "It's a cute bunny!", 5, ItemData.ItemType.Default)},
        {"small_health_potion", new HealthPotion("small_health_potion", "Small Health Potion", "A strange potion that fills you with new strength.", 100, ItemData.ItemType.Consumable, 1)},
        {"small_mana_potion", new ManaPotion("small_mana_potion", "Small Mana Potion", "A strange potion that gives you a warm tingling.", 100, ItemData.ItemType.Consumable, 10)},
        {"basic_clothes", new ArmorData("basic_clothes", "Normal Clothes", "A standard outfit you woke up in. Is it yours?", 1, ItemData.ItemType.Armor, 1, 1)},
        {"basic_sword", new WeaponData("basic_sword", "Glade Sword", "An old sword you found in the Glade.", 1, ItemData.ItemType.Weapon, 1, 1.0f, 1)}
    };
    
    private static Dictionary<string, Sprite> spriteCache = new Dictionary<string, Sprite>();

    public static ItemData GetItem(string itemID)
    {
        return itemDictionary.ContainsKey(itemID) ? itemDictionary[itemID] : null;
    }

    // Call this once at the start of the game
    public static void LoadSprites()
    {
        Sprite[] loadedSprites = Resources.LoadAll<Sprite>("Items"); // Loads all sprites in "Resources/Items"
        foreach(Sprite sprite in loadedSprites)
        {
            spriteCache[sprite.name] = sprite; // Store in dictionary
        }

        // Assign sprites to items
        foreach(KeyValuePair<string, ItemData> kvp in itemDictionary)
        {
            kvp.Value.sprite = GetSprite(kvp.Key); // Match sprite by name
        }
    }

    // Get a sprite by name
    private static Sprite GetSprite(string name)
    {
        if (spriteCache.TryGetValue(name, out Sprite sprite))
            return sprite;

        Debug.LogWarning($"Sprite not found for item: {name}");
        return null;
    }
}

    

