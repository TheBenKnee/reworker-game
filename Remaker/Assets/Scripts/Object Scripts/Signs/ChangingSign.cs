using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangingSign : Interactable
{
    [SerializeField] private GameObject myDialogBox;
    [SerializeField] private Text dialogText;
    [SerializeField] private StringValue[] signTexts;
    [SerializeField] private GameObject[] neededGameObjects;
    [SerializeField] private bool dialogActive = false;
    [SerializeField] private int signCase;

    // Update is called once per frame
    public void Update()
    {
        if(playerInRange && Input.GetButtonDown("Interact"))
        {
            if (!dialogActive)
            {
                dialogActive = true;
                checkCondition();
            }
            else
            {
                myDialogBox.SetActive(false);
                dialogActive = false;
            }
        }
    }

    private void checkCondition()
    {
        switch(signCase)
        {
            case 0: //Checks if player has picked up sword
                dialogActive = true;
                if(PixelCrushers.DialogueSystem.DialogueLua.GetVariable("HasSword").AsBool)
                {
                    dialogText.text = signTexts[1].value;
                }
                else
                {
                    neededGameObjects[0].GetComponent<AnimatorController>().SetAnimParameter("hasSword", true);
                    PixelCrushers.DialogueSystem.DialogueLua.SetVariable("HasSword", true);
                    dialogText.text = signTexts[0].value;
                }
                myDialogBox.SetActive(dialogActive);
                break;
            case 1:
                if(!PixelCrushers.DialogueSystem.DialogueLua.GetVariable("HasSword").AsBool)
                {
                    dialogActive = true;
                    dialogText.text = signTexts[0].value;
                    myDialogBox.SetActive(dialogActive);
                }
                else
                {
                    neededGameObjects[0].GetComponent<StateMachine>().ChangeState(GenericState.stun);
                    this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    neededGameObjects[1].GetComponent<BoulderDestruction>().startBoulder();
                }
                break;
            default:
                break;
        }
        
    }

    private void signRead()
    {
        switch(signCase)
        {
            case 0: //Checks if player has picked up sword
                if(PixelCrushers.DialogueSystem.DialogueLua.GetVariable("PlayerGender").AsInt == 1)
                {
                    Debug.Log("Here somehow");
                }
                break;
            case 1:
                break;
            default:
                break;
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
