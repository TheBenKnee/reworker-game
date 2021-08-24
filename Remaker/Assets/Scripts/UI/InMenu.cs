using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InMenu : MonoBehaviour
{
    private GameObject defaultUI;

    public void inMenu()
    {
        GameObject[] myUI = GameObject.FindGameObjectsWithTag("DefaultUI");
        if(myUI.Length > 0)
        {
            defaultUI = GameObject.FindGameObjectsWithTag("DefaultUI")[0];
        }
        defaultUI.transform.gameObject.SetActive(false);
    }

    public void outMenu()
    {
        GameObject[] myUI = GameObject.FindGameObjectsWithTag("DefaultUI");
        if(myUI.Length > 0)
        {
            defaultUI = GameObject.FindGameObjectsWithTag("DefaultUI")[0];
        }
        defaultUI.transform.gameObject.SetActive(true);
    }

}
