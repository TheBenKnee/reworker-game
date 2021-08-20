using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    private string screenResolution;
    [SerializeField] private List<Button> resolutionButtons = new List<Button>();

    public void selectResolution()
    {
        for(int i = 0; i < resolutionButtons.Count; i++)
        {
            resolutionButtons[i].gameObject.SetActive(!resolutionButtons[i].gameObject.activeSelf);
        }
    }

    public void changeResolution(int option)
    {
        switch(option)
        {
            case 0:
                Screen.SetResolution(1350, 1080, true);
                break;
            case 1:
                Screen.SetResolution(2700, 2160, true);
                break;
        }
        
    }

    public void goFullscreen()
    {
        Screen.fullScreen = true;
    }

    public void goWindowed()
    {
        Screen.fullScreen = false;
    }
}
