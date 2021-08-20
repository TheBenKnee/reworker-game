using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Inventory/Inventory Item", fileName = "New Inventory Item")]
[System.Serializable]
public class InventoryItem : ScriptableObject
{
    public Sprite mySprite;
    public string myName;
    public string myDescription;
    public bool isUsable;
    public bool isUnique;
    public int numberHeld = 0;
    public UnityEvent thisEvent;
    public int idNum;

    public void Use()
    {
        thisEvent.Invoke();
    }

    public void DecreaseAmount(int amountToDecrease)
    {
        numberHeld -= amountToDecrease;
        if (numberHeld < 0)
        {
            numberHeld = 0;
        }
    }
}