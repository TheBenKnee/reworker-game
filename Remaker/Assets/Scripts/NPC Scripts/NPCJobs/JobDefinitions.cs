using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NPCState
{
    idle,
    walk,
    attack,
    stun,
    defeated,
    winded
}

public enum Job
{
    FollowPlayer,
    MeleeEnemy,
    RangedEnemy,
    DodgeEnemy,
    HealPlayer,
    NavigateToEnemy,
    Winded
};

public class JobDefinitions : MonoBehaviour
{
    public GenericState myState;

    public void ChangeState(GenericState newState)
    {
        if (myState != newState)
        {
            myState = newState;
        }
    }
}
