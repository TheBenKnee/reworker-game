using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{

    [SerializeField] private GameObject deathEffect;
    [SerializeField] private LootTable myLootTable;
    private StateMachine thisStateMachine;

    // Start is called before the first frame update
    void Start()
    {
        thisStateMachine = GetComponent<StateMachine>();
        currentHealthValue = maxHealthValue;
    }

    public override void Damage(int damage)
    {
        base.Damage(damage);
        if (currentHealthValue <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        thisStateMachine.ChangeState(GenericState.dead);
        if(myLootTable)
        {
            Powerup current = myLootTable.LootPowerup();
            if (current != null)
            {
                Instantiate(current.gameObject, transform.position, Quaternion.identity);
            }
        }
        Instantiate(deathEffect, transform.position, transform.rotation);
        this.gameObject.SetActive(false);
    }
}