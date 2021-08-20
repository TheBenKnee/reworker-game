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
    [SerializeField] private FloatValue heartContainers;
    [SerializeField] private FloatValue playerCurrentHealth;

    // Start is called before the first frame update
    void Start()
    {
        InitHearts();
    }

    public void InitHearts()
    {
        //Activates and displays all hearts as full
        for(int i = 0; i < heartContainers.value; i++)
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
        //Gets the player's health numerically
        float tempHealth = playerCurrentHealth.value;
        //Goes through each of the player's hearts to animate them as full, half, or empty
        for(int i = 0; i < heartContainers.value; i++)
        {
            if(i <= tempHealth-1)
            {
                //Display a Full Heart
                hearts[i].sprite = fullHeart;
            }
            else
            {
                if(i >= tempHealth)
                {
                    //Display a Empty Heart
                    hearts[i].sprite = emptyHeart;
                }
                else
                {
                    //Display a Half Full Heart
                    hearts[i].sprite = halfFullHeart;
                }
            }
        }
    }
}
