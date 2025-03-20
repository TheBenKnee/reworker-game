using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartContainer : Powerup
{
    public PlayerHealth playerHealth;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerHealth = other.GetComponentInChildren(typeof(PlayerHealth)) as PlayerHealth;
            playerHealth.IncreaseMaxHealth(2);
            playerHealth.FullHeal();
            myPowerupNotification.Raise();
            Destroy(gameObject);
        }
    }
}
