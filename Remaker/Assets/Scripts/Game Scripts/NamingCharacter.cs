using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class NamingCharacter : MonoBehaviour
{
    [SerializeField] private GameSaveManager saveManager;
    [SerializeField] private TMP_InputField playerName; 
    [SerializeField] private GrowBerry myBerry;

    void Awake()
    {
        saveManager = GameObject.Find("SaveManager").GetComponent<GameSaveManager>();
    }

    public void EnterName()
    {
        switch(saveManager.activeSave)
        {
            case 1:
                saveManager.playerName1 = playerName.text;
                break;
            case 2:
                saveManager.playerName2 = playerName.text;
                break;
            case 3:
                saveManager.playerName3 = playerName.text;
                break;
            default:
                Debug.Log("Error: Cannot determine which player name to save to.");
                break;
        }
        myBerry.nameEntered = 0.1f;
        switch(playerName.text)
        {
            case "Ben":
            case "Benny":
            case "Benjamin":
            {
                myBerry.introDialogue.text = "Oh...welcome, " + playerName.text + ".";
                break;
            }
            case "Elvenar":
            {
                myBerry.introDialogue.text = "...you're not welcome here.";
                saveManager.activeSave = -2;
                SceneManager.LoadScene("MainMenu");
                break;
            }
            case "Fawaz":
            {
                myBerry.introDialogue.text = "*giggle* Welcome, " + playerName.text + ". I like your name a lot.";
                break;
            }
            default:
            {
                myBerry.introDialogue.text = "Welcome, " + playerName.text + ". That's a nice name.";
                break;
            }
        }
        gameObject.SetActive(false);
    }
}
