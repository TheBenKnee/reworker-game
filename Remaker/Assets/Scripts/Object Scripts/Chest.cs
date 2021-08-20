using UnityEngine;
using UnityEngine.UI;


public class Chest : Interactable
{
    
    [SerializeField] private AnimatorController anim;
    [SerializeField] private BoolValue openValue;
    [SerializeField] private bool isOpen;
    [SerializeField] private Notification chestNotification;
    [SerializeField] private SpriteValue spriteValue;
    [SerializeField] private Text dialogText;
    [SerializeField] private InventoryItem myItem;
    [SerializeField] private Inventory playerInventory;

    // Start is called before the first frame update
    void Start()
    {
        isOpen = openValue.value;
        if (isOpen)
        {
            anim.SetAnimParameter("isOpen", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange && Input.GetButtonUp("Interact"))
        {
            if (isOpen)
            {
                return;
            }
            DisplayContents();
        }
    }


    void DisplayContents()
    {
        isOpen = !isOpen;
        anim.SetAnimParameter("isOpen", true);
        openValue.value = isOpen;
        openValue.resetValue = isOpen;
        spriteValue.value = myItem.mySprite;
        dialogText.text = myItem.myDescription;
        chestNotification.Raise();
        Debug.Log("Notification Raised");
        playerInventory.AddItem(myItem);
        contextClueNotification.Raise();
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(otherTag) && !other.isTrigger)
        {
            playerInRange = true;
            if (!isOpen)
            {
                contextClueNotification.Raise();
            }
        }
    }

    protected override void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(otherTag) && !other.isTrigger)
        {
            playerInRange = false;
            if (!isOpen)
            {
                contextClueNotification.Raise();
            }
        }
    }
    
}