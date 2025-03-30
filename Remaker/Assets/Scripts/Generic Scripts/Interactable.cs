using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    [SerializeField] public bool playerInRange;
    [SerializeField] public string otherTag;
    [SerializeField] public Notification contextClueOn;
    [SerializeField] public Notification contextClueOff;

    public void ManualRaiseNotification()
    {
        contextClueOn.Raise();
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(otherTag) && !other.isTrigger)
        {
            playerInRange = true;
            contextClueOn.Raise();
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(otherTag) && !other.isTrigger)
        {
            playerInRange = false;
            contextClueOff.Raise();
        }
    }
}