using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{

    [Header("Inventory Information")]
    [SerializeField] private PlayerManager player;
    [SerializeField] private GameObject blankInventorySlot;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private GameObject useButton;
    public InventoryItem currentItem;

    public void SetTextAndButton(string description, bool buttonActive)
    {
        descriptionText.text = description;
        if(buttonActive)
        {
            useButton.SetActive(true);
        }
        else
        {
            useButton.SetActive(false);
        }
    }

    void MakeInventorySlots()
    {
        if(player != null)
        {
            foreach(KeyValuePair<string, InventoryItem> kvp in player.GetInventory())
            {
                if(kvp.Value.quantity > 0)
                {
                    GameObject temp = Instantiate(blankInventorySlot, inventoryPanel.transform.position, Quaternion.identity);
                    temp.transform.SetParent(inventoryPanel.transform);
                    InventorySlot newSlot = temp.GetComponent<InventorySlot>();
                    if (newSlot)
                    {
                        newSlot.Setup(kvp.Value, this);
                    }
                }
            }
        }
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        ItemDatabase.LoadSprites();
        ClearInventorySlots();
        MakeInventorySlots();
        SetTextAndButton("", false);
    }

    public void SetupDescriptionAndButton(string newDescriptionString, bool isButtonUsable, InventoryItem newItem)
    {
        descriptionText.text = newDescriptionString;
        useButton.SetActive(isButtonUsable);
        currentItem = newItem;
    }

    public void ClearInventorySlots()
    {
        for(int i = 0; i < inventoryPanel.transform.childCount; i++)
        {
            Destroy(inventoryPanel.transform.GetChild(i).gameObject);
        }
    }

    public void UseButtonPressed()
    {
        if(currentItem != null)
        {
            player.UseItem(currentItem.item.itemID);
            //Clear all inventory slots
            ClearInventorySlots();
            //Re-add the items
            MakeInventorySlots();
            if(currentItem.quantity == 0)
            {
                SetTextAndButton("", false);
            }
        }
    }
}
