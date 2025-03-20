using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq.Expressions;

public class InventorySlot : MonoBehaviour
{

    [Header("UI Stuff to change")]
    [SerializeField] private TextMeshProUGUI itemNumberText;
    [SerializeField] private Image itemImage;

    [Header("Variables from the item")]
    private InventoryItem thisItem;
    private InventoryManager thisManager;

    public void Setup(InventoryItem newItem, InventoryManager newManager)
    {
        thisItem = newItem;
        thisManager = newManager;
        if (thisItem != null)
        {
            itemImage.sprite = thisItem.item.sprite;
            itemNumberText.text = "" + thisItem.quantity;
        }
    }

    public void ClickedOn()
    {
        if(thisItem != null)
        {
            bool isUsable = thisItem.item.itemType == ItemData.ItemType.Consumable || thisItem.item.itemType == ItemData.ItemType.Usable;
            thisManager.SetupDescriptionAndButton(thisItem.item.description, isUsable, thisItem);
        }
    }
}
