using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogNPC : Interactable
{
    //The middle man dialog value
    [SerializeField] private TextAssetValue dialogValue;
    //NPC's dialog
    [SerializeField] private TextAsset myDialog;
    //Notif to activate dialog canvas
    [SerializeField] private Notification branchingDialogNotification;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInRange)
        {
            if(Input.GetButtonDown("Interact"))
            {
                dialogValue.value = myDialog;
                branchingDialogNotification.Raise();
            }
        }
    }
}
