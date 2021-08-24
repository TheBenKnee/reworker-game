using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class NamingCharacter : MonoBehaviour
{
    [SerializeField] private TMP_InputField playerName; 
    [SerializeField] private GrowBerry myBerry;

    public void EnterName()
    {
        PixelCrushers.DialogueSystem.DialogueLua.SetVariable("PlayerName", playerName.text);
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
                PixelCrushers.DialogueSystem.DialogueLua.SetVariable("SaveNumber", -1);
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
