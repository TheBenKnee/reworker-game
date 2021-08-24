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

    [SerializeField] private GameObject gameSaver;

    private int activeSave = -1;

    private int[] progress = new int[3];

    void Awake()
    {
        //Debug.Log("Panel Manager Waking");

        // for(int i = 0; i < 3; i++)
        // {
        //     Debug.Log(PixelCrushers.SaveSystem.HasSavedGameInSlot(i));
        // }
        // Debug.Log(PixelCrushers.SaveSystem.GetCurrentSceneName());
        // Debug.Log(PixelCrushers.SaveSystem.GetCurrentSceneIndex());
        
        PixelCrushers.SavedGameDataStorer gameSaver = GameObject.Find("Dialogue Manager").GetComponent<PixelCrushers.SavedGameDataStorer>();

        for(int x = 0; x < 3; x++)
        {
            PixelCrushers.SavedGameData myData = gameSaver.RetrieveSavedGameData(x+1);
            string s = myData.GetData("Dialogue Manager");

            //string s = PixelCrushers.DialogueSystem.PersistentDataManager.GetSaveData();
            // Debug.Log(s);
            int memory = 0;
            string percent = "";
            for(int i = 0; i < s.Length; i++)
            {
                if(memory == 5)
                {
                    if(s[i] == 'a' || s[i] == 'A')
                    {
                        continue;
                    }
                    for(int j = 0; j < 3; j++)
                    {
                        if(s[i+1+j] == ',' || s[i+1+j] == ';')
                        {
                            break;
                        }
                        else
                        {
                            percent += s[i+1+j];
                        }
                    }
                    break;
                }
                else
                {
                    if(s[i] == 'a' || s[i] == 'A')
                    {
                        memory += 1;
                    }
                    else
                    {
                        memory = 0;
                    }
                }
            }
            progress[x] = int.Parse(percent);
        }
        //Debug.Log(percent);
    }

    public void PlayButton()
    {
        // saveManager.ProgressLoad();

        save1.gameObject.SetActive(!save1.gameObject.activeSelf);
        save2.gameObject.SetActive(!save2.gameObject.activeSelf);
        save3.gameObject.SetActive(!save3.gameObject.activeSelf);
        
        TextMeshProUGUI saveTMU = save1.gameObject.GetComponentInChildren(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
        saveTMU.text = "Save 1 \n " +  progress[0] + "%";// + saveManager.progress1.ToString() + "%";
        saveTMU = save2.gameObject.GetComponentInChildren(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
        saveTMU.text = "Save 2 \n " +  progress[1] + "%";// + saveManager.progress2.ToString() + "%";
        saveTMU = save3.gameObject.GetComponentInChildren(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
        saveTMU.text = "Save 3 \n " +  progress[2] + "%";// + saveManager.progress3.ToString() + "%";

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
            SceneManager.LoadScene("Glade");
        }
        PixelCrushers.DialogueSystem.DialogueLua.SetVariable("SaveNumber", activeSave);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
