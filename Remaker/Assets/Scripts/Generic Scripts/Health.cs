using UnityEngine;

/*
 * This script is a generic health component for
 * any item that needs to have health.  This can
 * be added to the player, enemies, pots or grass
 * in the scene.  It can also be extended by
 * inheriting from it for specific interactions desired.
 */

public class Health : MonoBehaviour
{
    [Tooltip("Max and current health \n Set this to one for pots")]
    [Header("Health values")]
    [SerializeField] protected float maxHealthValue;
    [SerializeField] protected float currentHealthValue;

    public void SetUpHealth(int amount)
    {
        currentHealthValue = amount;
        maxHealthValue = amount;
    }
    public void SetHealth(int amount)
    {
        currentHealthValue = amount;
    }

    public virtual void Damage(int damage)
    {
        currentHealthValue -= damage;
        if (currentHealthValue <= 0)
        {
            currentHealthValue = 0;
        }
    }

    public virtual void Heal(int amount)
    {
        currentHealthValue += amount;
        if (currentHealthValue > maxHealthValue)
        {
            currentHealthValue = maxHealthValue;
        }
    }

    public void Kill()
    {
        currentHealthValue = 0;
    }

    public virtual void FullHeal()
    {
        currentHealthValue = maxHealthValue;
    }
}