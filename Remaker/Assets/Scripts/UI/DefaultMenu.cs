using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DefaultMenu : MonoBehaviour
{
    [SerializeField] private string levelToLoad;
    [SerializeField] private VectorValue playerPosition;
    [SerializeField] private Vector2 playerPos;

    [SerializeField] private Button save1;
    [SerializeField] private Button save2;
    [SerializeField] private Button save3;

    [SerializeField] private Button cont;
    [SerializeField] private Button del;

    [SerializeField] private GameSaveManager saveManager;


    void Awake()
    {
        //Debug.Log("Panel Manager Waking");
        saveManager = GameObject.Find("SaveManager").GetComponent<GameSaveManager>();
    }

    public void PlayButton()
    {
        saveManager.ProgressLoad();

        save1.gameObject.SetActive(!save1.gameObject.activeSelf);
        save2.gameObject.SetActive(!save2.gameObject.activeSelf);
        save3.gameObject.SetActive(!save3.gameObject.activeSelf);
        
        TextMeshProUGUI saveTMU = save1.gameObject.GetComponentInChildren(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
        saveTMU.text = "Save 1 \n " + saveManager.progress1.ToString() + "%";
        saveTMU = save2.gameObject.GetComponentInChildren(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
        saveTMU.text = "Save 2 \n " + saveManager.progress2.ToString() + "%";
        saveTMU = save3.gameObject.GetComponentInChildren(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
        saveTMU.text = "Save 3 \n " + saveManager.progress3.ToString() + "%";

        saveManager.activeSave = -1;
        cont.gameObject.SetActive(false);
        del.gameObject.SetActive(false);
    }

    public void SaveSelect(int option)
    {
        if(saveManager.activeSave != option)
        {
            TextMeshProUGUI saveTMU;
            saveManager.activeSave = option;
            cont.gameObject.SetActive(true);
            del.gameObject.SetActive(true);
            switch(option)
            {
                case 1:
                    saveTMU = cont.gameObject.GetComponentInChildren(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
                    if(saveManager.progress1 > 0)
                    {
                        saveTMU.text = "Continue";
                        del.interactable = true;
                    }
                    else
                    {
                        saveTMU.text = "New";
                        del.interactable = false;
                    }
                    break;
                case 2:
                    saveTMU = cont.gameObject.GetComponentInChildren(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
                    if(saveManager.progress2 > 0)
                    {
                        saveTMU.text = "Continue";
                        del.interactable = true;
                    }
                    else
                    {
                        saveTMU.text = "New";
                        del.interactable = false;
                    }
                    break;
                case 3:
                    saveTMU = cont.gameObject.GetComponentInChildren(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
                    if(saveManager.progress3 > 0)
                    {
                        saveTMU.text = "Continue";
                        del.interactable = true;
                    }
                    else
                    {
                        saveTMU.text = "New";
                        del.interactable = false;
                    }
                    break;
                default:
                    Debug.Log("Save selected not recognized.");
                    saveTMU = cont.gameObject.GetComponentInChildren(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
                    saveTMU.text = "Excuse me?";
                    return;
            }
        }
        else
        {
            saveManager.activeSave = -1;
            cont.gameObject.SetActive(false);
            del.gameObject.SetActive(false);
        }
    }

    public void DeleteSave()
    {
        saveManager.ResetSave();
        saveManager.activeSave = -1;
        cont.gameObject.SetActive(false);
        del.gameObject.SetActive(false);
        save1.gameObject.SetActive(false);
        save2.gameObject.SetActive(false);
        save3.gameObject.SetActive(false);
    }

    public void Proceed()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
