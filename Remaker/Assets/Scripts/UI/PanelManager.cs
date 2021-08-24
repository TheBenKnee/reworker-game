using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelManager : MonoBehaviour
{
    // private GameSaveManager myGameManager;
    [SerializeField] private bool isPaused = false;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject introPanel;
    [SerializeField] private GameObject saveButton;
    [SerializeField] private FloatValue gameSpeed;  //Making this a FloatValue instead of a hardcoded '1' allows us to preserve the speed of the game in the event of a game speed change (slow mo/speed up)
    [SerializeField] private string menuSceneString;

    // Update is called once per frame
    void Update()
    {
        // //PAUSE BUTTON
        if (!introPanel.activeSelf && Input.GetButtonUp("Pause"))
        {
            for(int i = 0; i < this.gameObject.transform.childCount; i++)
            {
                if(this.gameObject.transform.GetChild(i).gameObject.activeSelf && this.gameObject.transform.GetChild(i).gameObject != pauseMenu)
                {
                    //Just turn panel off
                    ChangePanel(this.gameObject.transform.GetChild(i).gameObject);
                    return;
                }
            }
            //If reached, no other panels were active
            ChangePanel(pauseMenu);
        }
        
        //INVENTORY BUTTON
        if (!introPanel.activeSelf && Input.GetButtonDown("Inventory"))
        {
            for(int i = 0; i < this.gameObject.transform.childCount; i++)
            {
                if(this.gameObject.transform.GetChild(i).gameObject.activeSelf && this.gameObject.transform.GetChild(i).gameObject != inventoryPanel)
                {
                    //If other panel is open, don't open inventory panel
                    return;
                }
            }
            ChangePanel(inventoryPanel);
        }
    }

    void ChangePanel(GameObject panel)
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            panel.SetActive(true);
            Time.timeScale = 0f;     
        }
        else
        {
            panel.SetActive(false);
            Time.timeScale = gameSpeed.value;
        }
    }

    public void ResumeButton()
    {
        ChangePanel(pauseMenu);
    }

    public void QuitButton()
    {
        introPanel.SetActive(true);        
        Time.timeScale = gameSpeed.value;
        // myGameManager.doDisable();
        // myGameManager.activeSave = -1;
        PixelCrushers.DialogueSystem.DialogueLua.SetVariable("SaveNumber", -1);
        SceneManager.LoadScene(menuSceneString);
    }

    public void LoadGame()
    {
        int currentSave = PixelCrushers.DialogueSystem.DialogueLua.GetVariable("SaveNumber").AsInt;
        Debug.Log("Manually loading scene: " + currentSave);
        PixelCrushers.SaveSystemMethods test = saveButton.gameObject.GetComponentInChildren(typeof(PixelCrushers.SaveSystemMethods)) as PixelCrushers.SaveSystemMethods;
        test.LoadFromSlot(currentSave);
    }

    public void SaveGame()
    {
        //Debug.Log(PixelCrushers.DialogueSystem.DialogueLua.GetVariable("SaveNumber").AsInt);
        // PixelCrushers.DialogueSystem.DialogueLua.SetVariable("SaveNumber", 1);
        int currentSave = PixelCrushers.DialogueSystem.DialogueLua.GetVariable("SaveNumber").AsInt;
        Debug.Log("Manually saving scene: " + currentSave);
        PixelCrushers.SaveSystemMethods test = saveButton.gameObject.GetComponentInChildren(typeof(PixelCrushers.SaveSystemMethods)) as PixelCrushers.SaveSystemMethods;
        test.SaveSlot(currentSave);
        //PixelCrushers.SaveSystemMethods.SaveSlot(2);
        // switch(myGameManager.activeSave)
        // {
        //     case 1:
        //         myGameManager.progress1 = myGameManager.progressTmp;
        //         for(int i = 0; i < myGameManager.playerPersonalityTmp.Length; i++)
        //         {
        //             myGameManager.playerPersonality1[i] = myGameManager.playerPersonalityTmp[i];
        //         }
        //         break;
        //     case 2:
        //         myGameManager.progress2 = myGameManager.progressTmp;
        //         for(int i = 0; i < myGameManager.activeSave; i++)
        //         {
        //             myGameManager.playerPersonality2[i] = myGameManager.playerPersonalityTmp[i];
        //         }
        //         break;
        //     case 3:
        //         myGameManager.progress3 = myGameManager.progressTmp;
        //         for(int i = 0; i < myGameManager.activeSave; i++)
        //         {
        //             myGameManager.playerPersonality3[i] = myGameManager.playerPersonalityTmp[i];
        //         }
        //         break;
        //     default:
        //         Debug.Log("Save # not recognized.");
        //         return;
        // }
    }

    void Awake()
    {
        // //Debug.Log("Panel Manager Waking");
        // myGameManager = GameObject.Find("SaveManager").GetComponent<GameSaveManager>();
        // switch(myGameManager.activeSave)
        // {
        //     case 1:
        //     {
        //         if(myGameManager.progress1 >= 1)
        //         {
        //             introPanel.gameObject.SetActive(false);
        //         }
        //         break;
        //     }
        //     case 2:
        //     {
        //         if(myGameManager.progress2 >= 1)
        //         {
        //             introPanel.gameObject.SetActive(false);
        //         }
        //         break;
        //     }
        //     case 3:
        //     {
        //         if(myGameManager.progress3 >= 1)
        //         {
        //             introPanel.gameObject.SetActive(false);
        //         }
        //         break;
        //     }
        //     default:
        //     {
        //         Debug.Log("In PanelManager, Active Save not detected.");
        //         break;
        //     }
        // }
        if(PixelCrushers.DialogueSystem.DialogueLua.GetVariable("Aaaaaa").AsInt > 0)
        {
            introPanel.gameObject.SetActive(false);
        }
    }

    public void doDisable()
    {
        introPanel.SetActive(true);
    }
}
