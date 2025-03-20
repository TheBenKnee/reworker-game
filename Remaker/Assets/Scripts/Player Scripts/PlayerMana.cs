using UnityEngine;

public class PlayerMana : Mana
{
    [SerializeField] private FlashColor flash;
    [SerializeField] private Notification updateHeartsUI;
    [SerializeField] private GameObject deathEffect;
    private StateMachine thisStateMachine;

    private void Start()
    {
        thisStateMachine = transform.parent.GetComponent<StateMachine>();
        SetUpMana((int)maxManaValue);
        currentManaValue = maxManaValue;
        updateHeartsUI.Raise();
    }

    public override void ReduceMana(int damage)
    {
        base.ReduceMana(damage);
        updateHeartsUI.Raise();
        if(currentManaValue > 0)
        {
            if (flash)
            {
                flash.StartFlash();
            }
        }
        else
        {
            Die();
        }
    }

    public override void RestoreMana(int amount)
    {
        currentManaValue += amount;
        if (currentManaValue > maxManaValue)
        {
            currentManaValue = maxManaValue;
        }
    }

    public void Die()
    {
        thisStateMachine.ChangeState(GenericState.dead);
        Instantiate(deathEffect, transform.position, transform.rotation);
        transform.parent.gameObject.SetActive(false);
    }

    public void IncreaseMaxMana()
    {
        if(maxManaValue < 5)
        {
            maxManaValue++;
        }      
        FullRestore();
    }

    public override void FullRestore()
    {
        currentManaValue = maxManaValue;
    }
}