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
    [SerializeField] private string menuSceneString = "MainMenu";
    [SerializeField] private StateMachine playerStateMachine;
    [SerializeField] private PlayerManager playerManager;

    // Update is called once per frame
    void Update()
    {
        if(playerStateMachine.myState != GenericState.stun)
        {
            // //PAUSE BUTTON
            if (Input.GetButtonUp("Pause"))
            {
                for(int i = 0; i < gameObject.transform.childCount; i++)
                {
                    if(gameObject.transform.GetChild(i).gameObject.activeSelf && gameObject.transform.GetChild(i).gameObject != pauseMenu)
                    {
                        //Just turn panel off
                        ChangePanel(gameObject.transform.GetChild(i).gameObject);
                        return;
                    }
                }
                //If reached, no other panels were active
                ChangePanel(pauseMenu);
            }
            
            //INVENTORY BUTTON
            if (Input.GetButtonDown("Inventory"))
            {
                for(int i = 0; i < gameObject.transform.childCount; i++)
                {
                    if(gameObject.transform.GetChild(i).gameObject.activeSelf && gameObject.transform.GetChild(i).gameObject != inventoryPanel)
                    {
                        //If other panel is open, don't open inventory panel
                        return;
                    }
                }
                ChangePanel(inventoryPanel);
            }
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
        // introPanel.SetActive(true);        
        Time.timeScale = 1f;
        PixelCrushers.DialogueSystem.DialogueLua.SetVariable("SaveNumber", -1);
        SceneManager.LoadScene(menuSceneString);
    }

    public void LoadGame()
    {
        int saveSlot = PixelCrushers.DialogueSystem.DialogueLua.GetVariable("SaveNumber").AsInt;
        Debug.Log("Manually loading from slot: " + saveSlot);
        // PixelCrushers.SaveSystem.LoadFromSlot(saveSlot);
        InventorySaveSystem.LoadInventory(playerManager.GetInventorySystem());
    }

    public void SaveGame()
    {
        int saveSlot = PixelCrushers.DialogueSystem.DialogueLua.GetVariable("SaveNumber").AsInt;
        Debug.Log("Manually saving to slot: " + saveSlot);
        // PixelCrushers.SaveSystem.SaveToSlot(saveSlot);
        InventorySaveSystem.SaveInventory(playerManager.GetInventorySystem());
    }

    void Awake()
    {
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
