using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveItem : MonoBehaviour
{
    [SerializeField] private SpriteRenderer mySprite;
    [SerializeField] private SpriteValue receivedSprite;
    [SerializeField] private FloatValue gameSpeed;
    [SerializeField] private AnimatorController anim;
    [SerializeField] private StateMachine myState;
    [SerializeField] private bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        mySprite.enabled = false;
        myState = GetComponentInParent(typeof(StateMachine)) as StateMachine;
        anim = GetComponentInParent(typeof(AnimatorController)) as AnimatorController;
    }


    public void ChangeSpriteState()
    {
        isActive = !isActive;
        if (isActive)
        {
            DisplaySprite();
        }
        else
        {
            DisableSprite();
        }
    }


    void DisplaySprite()
    {
        myState.ChangeState(GenericState.receiveItem);
        mySprite.enabled = true;
        mySprite.sprite = receivedSprite.value;
        Debug.Log("Setting receiving to true");
        Debug.Log("Receiving: " + anim.GetAnimBool("receiving"));
        anim.SetAnimParameter("receiving", true);
        Debug.Log("Receiving: " + anim.GetAnimBool("receiving"));
    }


    void DisableSprite()
    {
        myState.ChangeState(GenericState.idle);
        Debug.Log("Setting receiving to false");
        anim.SetAnimParameter("receiving", false);
        Debug.Log(anim.GetAnimBool("receiving"));
        mySprite.enabled = false;
    }
}