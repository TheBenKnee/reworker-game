using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField] private FlashColor flash;
    [SerializeField] private Notification updateHeartsUI;
    [SerializeField] private GameObject deathEffect;
    private StateMachine thisStateMachine;

    private void Start()
    {
        thisStateMachine = this.transform.parent.GetComponent<StateMachine>();
        SetUpHealth((int)maxHealthValue.value);
        currentHealthValue.value = maxHealthValue.value;
        updateHeartsUI.Raise();
    }

    public override void Damage(int damage)
    {
        base.Damage(damage);
        updateHeartsUI.Raise();
        if(currentHealthValue.value > 0)
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
        currentHealthValue.value += amount;
        if (currentHealthValue.value > maxHealthValue.value)
        {
            currentHealthValue.value = maxHealthValue.value;
        }
    }

    public void Die()
    {
        thisStateMachine.ChangeState(GenericState.dead);
        Instantiate(deathEffect, transform.position, transform.rotation);
        this.transform.parent.gameObject.SetActive(false);
    }

    public void increaseMaxHealth()
    {
        if(maxHealthValue.value < 5)
        {
            maxHealthValue.value++;
        }      
        FullHeal();
    }

    public override void FullHeal()
    {
        currentHealthValue.value = maxHealthValue.value;
    }
}