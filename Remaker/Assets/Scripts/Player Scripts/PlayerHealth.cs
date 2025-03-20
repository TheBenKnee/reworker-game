using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField] private FlashColor flash;
    [SerializeField] private Notification updateHeartsUI;
    [SerializeField] private GameObject deathEffect;
    private StateMachine thisStateMachine;

    private void Start()
    {
        thisStateMachine = transform.parent.GetComponent<StateMachine>();
        SetUpHealth(maxHealthValue);
        currentHealthValue = maxHealthValue;
        updateHeartsUI.Raise();
    }

    public override void Damage(int damage)
    {
        base.Damage(damage);
        updateHeartsUI.Raise();
        if(currentHealthValue > 0)
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

    public override void Heal(int amount)
    {
        currentHealthValue += amount;
        if (currentHealthValue > maxHealthValue)
        {
            currentHealthValue = maxHealthValue;
        }
    }

    public void Die()
    {
        thisStateMachine.ChangeState(GenericState.dead);
        Instantiate(deathEffect, transform.position, transform.rotation);
        transform.parent.gameObject.SetActive(false);
    }

    public void IncreaseMaxHealth(int healthIncreaseAmount)
    {
        if(maxHealthValue + healthIncreaseAmount < Constants.MAX_HEART_AMOUNT)
        {
            maxHealthValue += healthIncreaseAmount;
        }      
        FullHeal();
    }

    public override void FullHeal()
    {
        currentHealthValue = maxHealthValue;
    }
}