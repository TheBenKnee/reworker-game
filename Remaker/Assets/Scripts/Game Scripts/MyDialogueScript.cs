﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDialogueScript : MonoBehaviour
{
    [SerializeField] private FloatValue gameSpeed;
    [SerializeField] private GameObject defaultUI;

    public void startDialogue()
    {
        GameObject[] myUI = GameObject.FindGameObjectsWithTag("DefaultUI");
        if(myUI.Length > 0)
        {
            defaultUI = GameObject.FindGameObjectsWithTag("DefaultUI")[0];
        }
        Time.timeScale = 0f;
        defaultUI.transform.gameObject.SetActive(false);
    }

    public void endDialogue()
    {
        GameObject[] myUI = GameObject.FindGameObjectsWithTag("DefaultUI");
        if(myUI.Length > 0)
        {
            defaultUI = GameObject.FindGameObjectsWithTag("DefaultUI")[0];
        }
        defaultUI.transform.gameObject.SetActive(true);
        Time.timeScale = gameSpeed.value;
    }

}