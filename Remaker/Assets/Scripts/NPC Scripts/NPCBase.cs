using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCBase : MonoBehaviour
{

    [Header("State Machine")]
    protected StateMachine myStateMachine;
    protected AnimatorController anim;

    [Header("NPC Stats/Variables")]
    public FloatValue maxHealth;
    [SerializeField] protected NPCHealth health;
    public string npcName;
    private bool metPlayer = false;

    public virtual void Start()
    {
        //Initializing animator to the npcs animator
        anim = GetComponent<AnimatorController>();
        //Initializing SM to the npcs SM
        myStateMachine = GetComponent<StateMachine>();
        //Initializing state to idle
        myStateMachine.ChangeState(GenericState.idle);
        //Initializing health
        health.FullHeal();
    }
}