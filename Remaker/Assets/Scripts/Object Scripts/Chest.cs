using UnityEngine;
using UnityEngine.UI;


public class Chest : Interactable
{
    public int chestId;
    [SerializeField] private AnimatorController anim;
    [SerializeField] private bool isOpen = false;
    [SerializeField] private Notification chestNotification;
    [SerializeField] private SpriteValue spriteValue;
    [SerializeField] private Text dialogText;
    [SerializeField] private ItemData myItem;
    [SerializeField] private InventorySystem playerInventory;

    void OnEnable()
    {
        SaveableObjectManager.Instance.RegisterChest(this);
    }

    void OnDisable()
    {
        SaveableObjectManager.Instance.UnregisterChest(this);
    }

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

    public bool IsOpen()
    {
        return isOpen;
    }

    public void QuietOpen()
    {
        isOpen = true;
        anim.SetAnimParameter("isOpen", true);
    }

    void DisplayContents()
    {
        isOpen = true;
        anim.SetAnimParameter("isOpen", true);
        spriteValue.value = myItem.sprite;
        dialogText.text = myItem.description;
        chestNotification.Raise();
        playerInventory.AddItem(myItem, 1);
        contextClueOff.Raise();
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(otherTag) && !other.isTrigger)
        {
            playerInRange = true;
            if (!isOpen)
            {
                contextClueOn.Raise();
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
                contextClueOff.Raise();
            }
        }
    }
    
}