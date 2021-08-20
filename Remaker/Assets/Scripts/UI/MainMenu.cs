using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private GameObject settingsPanel;

    public void Credits()
    {
        creditsPanel.SetActive(true);
        gamePanel.SetActive(false);
    }

    public void Settings()
    {
        settingsPanel.SetActive(true);
        gamePanel.SetActive(false);
    }

    public void BackCredits()
    {
        gamePanel.SetActive(true);
        creditsPanel.SetActive(false);
    }

    public void BackSettings()
    {
        gamePanel.SetActive(true);
        settingsPanel.SetActive(false);
    }
}