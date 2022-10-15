using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : Interactable
{
    [SerializeField] private GameObject myDialogBox;
    [SerializeField] private Text dialogText;
    [SerializeField] private StringValue newSignText;
    [SerializeField] private bool dialogActive = false;

    // Update is called once per frame
    public void Update()
    {
        if (playerInRange && Input.GetButtonDown("Interact"))
        {
            dialogActive = !dialogActive;
            myDialogBox.SetActive(dialogActive);
            dialogText.text = newSignText.value;
        }
    }

    protected override void OnTriggerExit2D(Collider2D other)
    {
        base.OnTriggerExit2D(other);
        if (other.gameObject.CompareTag(otherTag) && !other.isTrigger)
        {
            if (dialogActive)
            {
                dialogActive = !dialogActive;
                myDialogBox.SetActive(dialogActive);
            }
        }
    }

}