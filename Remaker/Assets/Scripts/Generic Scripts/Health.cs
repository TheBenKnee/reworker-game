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
    [SerializeField] protected FloatValue maxHealthValue;
    [SerializeField] protected FloatValue currentHealthValue;

    public void SetUpHealth(int amount)
    {
        currentHealthValue.value = amount;
        maxHealthValue.value = amount;
    }
    public void SetHealth(int amount)
    {
        currentHealthValue.value = amount;
    }

    public virtual void Damage(int damage)
    {
        currentHealthValue.value -= damage;
        if (currentHealthValue.value <= 0)
        {
            currentHealthValue.value = 0;
        }
    }

    public virtual void Heal(int amount)
    {
        currentHealthValue.value += amount;
        if (currentHealthValue.value > maxHealthValue.value)
        {
            currentHealthValue.value = maxHealthValue.value;
        }
    }

    public void Kill()
    {
        currentHealthValue.value = 0;
    }

    public virtual void FullHeal()
    {
        currentHealthValue.value = maxHealthValue.value;
    }
}