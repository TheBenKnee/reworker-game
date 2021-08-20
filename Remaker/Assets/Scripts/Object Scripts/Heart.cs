using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : Powerup
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private int amountToIncrease;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            //Expects the player's health object to be a child of the player object
            playerHealth = other.GetComponentInChildren(typeof(PlayerHealth)) as PlayerHealth;
            playerHealth.Heal(amountToIncrease);
            myPowerupNotification.Raise();
            Destroy(this.gameObject);
        }
    }
}
