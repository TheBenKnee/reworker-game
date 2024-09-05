using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DefaultPanel : MonoBehaviour
{
    [SerializeField] private Button save1;
    [SerializeField] private Button save2;
    [SerializeField] private Button save3;

    [SerializeField] private Button cont;
    [SerializeField] private Button del;

    private int activeSave = -1;

    public void PlayButton()
    {
        save1.gameObject.SetActive(!save1.gameObject.activeSelf);
        save2.gameObject.SetActive(!save2.gameObject.activeSelf);
        save3.gameObject.SetActive(!save3.gameObject.activeSelf);

        activeSave = -1;
        cont.gameObject.SetActive(false);
        del.gameObject.SetActive(false);
    }

    public void SaveSelect(int option)
    {
        if(activeSave != option)
        {
            TextMeshProUGUI saveTMU;
            activeSave = option;
            cont.gameObject.SetActive(true);
            del.gameObject.SetActive(true);
            saveTMU = cont.gameObject.GetComponentInChildren(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
            if(PixelCrushers.SaveSystem.HasSavedGameInSlot(option))
            {
                saveTMU.text = "Continue";
                del.interactable = true;
            }
            else
            {
                saveTMU.text = "New";
                del.interactable = false;
            }
        }
        else
        {
            activeSave = -1;
            cont.gameObject.SetActive(false);
            del.gameObject.SetActive(false);
        }
    }

    public void DeleteSave()
    {
        PixelCrushers.SaveSystem.DeleteSavedGameInSlot(activeSave);
        activeSave = -1;
        cont.gameObject.SetActive(false);
        del.gameObject.SetActive(false);
        save1.gameObject.SetActive(false);
        save2.gameObject.SetActive(false);
        save3.gameObject.SetActive(false);
    }

    public void Proceed()
    {
        if(PixelCrushers.SaveSystem.HasSavedGameInSlot(activeSave))
        {
            PixelCrushers.SaveSystem.LoadFromSlot(activeSave);
        }
        else
        {
            SceneManager.LoadScene("Lake");
        }
        PixelCrushers.DialogueSystem.DialogueLua.SetVariable("SaveNumber", activeSave);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
