using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealEvent : MonoBehaviour
{
    [SerializeField] private FloatValue playerHealth;
    [SerializeField] private Notification healthNotification;

    public void Use(float amountToIncrease)
    {
        playerHealth.value += amountToIncrease;
        healthNotification.Raise();
    }
}
