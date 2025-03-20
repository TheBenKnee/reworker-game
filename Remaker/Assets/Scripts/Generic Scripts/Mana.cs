using UnityEngine;

/*
 * This script is a generic mana component for
 * any item that needs to have mana.  This can
 * be added to the player, enemies, pots or grass
 * in the scene.  It can also be extended by
 * inheriting from it for specific interactions desired.
 */

public class Mana : MonoBehaviour
{
    [Tooltip("Max and current mana \n Set this to one for pots")]
    [Header("Mana values")]
    [SerializeField] protected float maxManaValue;
    [SerializeField] protected float currentManaValue;

    public void SetUpMana(int amount)
    {
        currentManaValue = amount;
        maxManaValue = amount;
    }
    public void SetMana(int amount)
    {
        currentManaValue = amount;
    }

    public virtual void ReduceMana(int damage)
    {
        currentManaValue -= damage;
        if (currentManaValue <= 0)
        {
            currentManaValue = 0;
        }
    }

    public virtual void RestoreMana(int amount)
    {
        currentManaValue += amount;
        if (currentManaValue > maxManaValue)
        {
            currentManaValue = maxManaValue;
        }
    }

    public void ZeroOutMana()
    {
        currentManaValue = 0;
    }

    public virtual void FullRestore()
    {
        currentManaValue = maxManaValue;
    }
}