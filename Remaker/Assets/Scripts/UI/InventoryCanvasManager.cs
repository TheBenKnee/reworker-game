using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCanvasManager : MonoBehaviour
{

    private bool isPaused = false;
    [SerializeField] private FloatValue gameSpeed;  //Making this a FloatValue instead of a hardcoded '1' allows us to preserve the speed of the game in the event of a game speed change (slow mo/speed up)
    [SerializeField] private GameObject inventoryPanel;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            for(int i = 0; i < gameObject.transform.childCount; i++)
            {
                if(gameObject.transform.GetChild(i).gameObject.activeSelf && gameObject.transform.GetChild(i).gameObject != inventoryPanel)
                {
                    gameObject.transform.GetChild(i).gameObject.SetActive(false);
                }
            }
            ChangePause();
        }
    }

    public void ChangePause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            inventoryPanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            inventoryPanel.SetActive(false);
            Time.timeScale = gameSpeed.value;
        }
    }

    /*
     * The switching panels is unecessary now as I would prefer a  
     * seperate key for opening the pause and inventory panels.
     * 
     * Commented out instead of deleted in case I want to add in
     * a character tab for armor or a quest log accessable thru the inv.
     */

    /*
    public void SwitchPanels()
    {
        usingPausePanel = !usingPausePanel;
        if (usingPausePanel)
        {
            pausePanel.SetActive(true);
            inventoryPanel.SetActive(false);
        }
        else
        {
            inventoryPanel.SetActive(true);
            pausePanel.SetActive(false);
        }
    }
    */
}
