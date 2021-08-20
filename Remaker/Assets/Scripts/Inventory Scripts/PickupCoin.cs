using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PickupCoin : MonoBehaviour
{
    [SerializeField] private Inventory myInventory;
    [SerializeField] private TextMeshProUGUI descriptionText;
    //myGameManager = GameObject.Find("SaveManager").GetComponent<GameSaveManager>();
    private Image thisPurse;
    private GameSaveManager myGameManager;
    private int lifeTime = 200;
    private bool isShowing = true;
    private Color initialColor;
    private Color changedColor;
    private Color initialText;
    private Color changedText;

    void FixedUpdate()
    {
        if(isShowing)
        {
            //Debug.Log(thisPurse.color.a);
            if(lifeTime <= 0)
            {
                turnOff();
            }
            if(lifeTime < 100)
            {
                //Decrease opacity
                changedColor.a -= (float)0.01;
                changedText.a -= (float)0.01;
                thisPurse.color = changedColor;
                descriptionText.color = changedText;
            }
            lifeTime -= 1;
        }
    }

    public void turnOn()
    {
        thisPurse.color = initialColor;
        changedColor = initialColor;
        descriptionText.color = initialText;
        changedText = initialText;
        isShowing = true;
        lifeTime = 200;
    }

    private void turnOff()
    {
        isShowing = false;
    }

    public void AddCoin()
    {
        turnOn();
        myInventory.AddCoins(1);
        descriptionText.text = myInventory.coins.ToString();
    }

    void OnEnable()
    {
        thisPurse = gameObject.GetComponent(typeof(Image)) as Image;
        initialColor = thisPurse.color;
        changedColor = thisPurse.color;
        initialText = descriptionText.color;
        changedText = descriptionText.color;
        myGameManager = GameObject.Find("SaveManager").GetComponent<GameSaveManager>();
        switch(myGameManager.activeSave)
        {
            case 1:
            {
                myInventory.coins = myGameManager.player1Coins;
                break;
            }
            case 2:
            {
                myInventory.coins = myGameManager.player2Coins;
                break;
            }
            case 3:
            {
                myInventory.coins = myGameManager.player3Coins;
                break;
            }
            default:
            {
                Debug.Log("In PickupCoin, Active Save not detected.");
                break;
            }
        }
        descriptionText.text = myInventory.coins.ToString();
    }
}
