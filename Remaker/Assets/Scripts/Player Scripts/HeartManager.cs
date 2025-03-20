using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite halfFullHeart;
    [SerializeField] private Sprite emptyHeart;
    [SerializeField] private PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        InitHearts();
    }

    public void InitHearts()
    {
        //Activates and displays all hearts as full
        for(int i = 0; i <= (playerHealth.GetMaxHealth() - 1) / 2; i++)
        {
            //Slightly redundant check to ensure extra hearts aren't incorrectly created
            if(i < hearts.Length)
            {
                hearts[i].gameObject.SetActive(true);
                hearts[i].sprite = fullHeart;
            }
        }
    }

    public void UpdateHearts()
    {
        //Refreshes check to see if more hearts should be added.
        InitHearts();
        int currentHealth = playerHealth.GetCurrentHealth();
        int maxHealth = playerHealth.GetMaxHealth();
        int heartCount = maxHealth / 2; // Each heart represents 2 HP

        for (int i = 0; i < heartCount; i++)
        {
            int heartHealth = currentHealth - (i * 2); // How much health is left for this heart slot

            if (heartHealth >= 2)
            {
                hearts[i].sprite = fullHeart; // Full heart
            }
            else if (heartHealth == 1)
            {
                hearts[i].sprite = halfFullHeart; // Half heart
            }
            else
            {
                hearts[i].sprite = emptyHeart; // Empty heart
            }
        }
    }
}
