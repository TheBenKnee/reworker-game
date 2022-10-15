using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnetimeSign : Interactable
{
    [SerializeField] private GameObject myDialogBox;
    [SerializeField] private Text dialogText;
    [SerializeField] private StringValue newSignText;
    [SerializeField] private bool dialogActive = false;

    // Update is called once per frame
    public void Update()
    {
        if(playerInRange && Input.GetButtonDown("Interact"))
        {
            if (!dialogActive)
            {
                dialogActive = true;
                myDialogBox.SetActive(dialogActive);
                dialogText.text = newSignText.value;
            }
            else
            {
                Debug.Log("Destroying");
                DestroyMe();
            }
        }
    }

    private void DestroyMe()
    {
        myDialogBox.SetActive(false);
        this.gameObject.SetActive(false);
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
