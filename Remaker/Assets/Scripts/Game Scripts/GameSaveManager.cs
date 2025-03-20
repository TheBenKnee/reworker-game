using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSaveManager : MonoBehaviour
{
    public static string save1Folder;
    public static string save2Folder;
    public static string save3Folder;
    public static string saveFolder; 

    private static GameSaveManager gameSave;
    private bool shouldSave;
    [SerializeField] private int saveFile;
    // [SerializeField] private Inventory myInventory;
    [SerializeField] private List<ScriptableObject> objects = new List<ScriptableObject>();

    public int activeSave = -1;
    public int progress1;
    public int progress2;
    public int progress3;

    public string playerName1;
    public string playerName2;
    public string playerName3;

    public int player1Gender;
    public int player2Gender;
    public int player3Gender;

    public int player1Coins;
    public int player2Coins;
    public int player3Coins;

    public int[] playerPersonality1 = new int[5] { 50, 50, 50, 50, 50};
    public int[] playerPersonality2 = new int[5] { 50, 50, 50, 50, 50};
    public int[] playerPersonality3 = new int[5] { 50, 50, 50, 50, 50};

    public int progressTmp;
    public int[] playerPersonalityTmp = new int[5];
   
    public Scene currentScene;

    void Awake()
    {
        if(gameSave == null)
        {
            DontDestroyOnLoad(gameObject);
            shouldSave = true;
            gameSave = this;
        }
        else
        {
            if(gameSave != this)
            {
                shouldSave = false;
                Destroy(gameObject);
            }
        }
        save1Folder = Application.persistentDataPath + "/Save1/";
        save2Folder = Application.persistentDataPath + "/Save2/";
        save3Folder = Application.persistentDataPath + "/Save3/";
        saveFolder = Application.persistentDataPath + "/Saves/";
        currentScene = SceneManager.GetActiveScene();
    }

    private void OnEnable()
    {
        LoadScriptables();
        // myInventory.myInventory.Clear();
        // InventoryLoad();
        ProgressLoad();
    }

    public void doDisable()
    {
        this.OnDisable();
    }

    private void OnDisable()
    {
        string sceneName = currentScene.name;
        if(shouldSave && sceneName != "MainMenu")
        {
            switch(activeSave)
            {
                case 1:
                {
                    if(progress1 > 0)
                    {
                        SaveScriptables();
                        // InventorySave();
                        ProgressSave();                       
                    }
                    break;
                }
                case 2:
                {
                    if(progress2 > 0)
                    {
                        SaveScriptables();
                        // InventorySave();
                        ProgressSave();
                    }
                    break;
                }
                case 3:
                {
                    if(progress3 > 0)
                    {
                        SaveScriptables();
                        // InventorySave();
                        ProgressSave();
                    }
                    break;
                }
            }
        }
    }

    public void SaveScriptables()
    {
        if(activeSave > 0)
        {
            Debug.Log("Saving objs to " + activeSave);
            for(int i = 0; i < objects.Count; i++)
            {
                FileStream file;
                switch(activeSave)
                {
                    case 1:
                    {
                        file = File.Create(save1Folder + string.Format("/{0}.dat", i));
                        BinaryFormatter binary = new BinaryFormatter();
                        var json = JsonUtility.ToJson(objects[i]);
                        binary.Serialize(file, json);
                        file.Close();
                        break;
                    }
                    case 2:
                    {
                        file = File.Create(save2Folder + string.Format("/{0}.dat", i));
                        BinaryFormatter binary = new BinaryFormatter();
                        var json = JsonUtility.ToJson(objects[i]);
                        binary.Serialize(file, json);
                        file.Close();
                        break;
                    }
                    case 3:
                    {
                        file = File.Create(save3Folder + string.Format("/{0}.dat", i));
                        BinaryFormatter binary = new BinaryFormatter();
                        var json = JsonUtility.ToJson(objects[i]);
                        binary.Serialize(file, json);
                        file.Close();
                        break;
                    }
                }
                
            }
        }
        else
        {
            //Debug.Log("Wanted to save objs to " + activeSave);
        }
        
    }

    public void LoadScriptables()
    {
        if(activeSave > 0)
        {
            Debug.Log("Loading objs from " + activeSave);
            for (int i = 0; i < objects.Count; i++)
            {
                switch(activeSave)
                {
                    case 1:
                    {
                        if(File.Exists(save1Folder + string.Format("/{0}.dat", i)))
                        {
                            FileStream file = File.Open(save1Folder + string.Format("/{0}.dat", i), FileMode.Open);
                            BinaryFormatter binary = new BinaryFormatter();
                            JsonUtility.FromJsonOverwrite((string)binary.Deserialize(file), objects[i]);
                            file.Close();
                        }
                        break;
                    }
                    case 2:
                    {
                        if(File.Exists(save2Folder + string.Format("/{0}.dat", i)))
                        {
                            FileStream file = File.Open(save2Folder + string.Format("/{0}.dat", i), FileMode.Open);
                            BinaryFormatter binary = new BinaryFormatter();
                            JsonUtility.FromJsonOverwrite((string)binary.Deserialize(file), objects[i]);
                            file.Close();
                        }
                        break;
                    }
                    case 3:
                    {
                        if(File.Exists(save3Folder + string.Format("/{0}.dat", i)))
                        {
                            FileStream file = File.Open(save3Folder + string.Format("/{0}.dat", i), FileMode.Open);
                            BinaryFormatter binary = new BinaryFormatter();
                            JsonUtility.FromJsonOverwrite((string)binary.Deserialize(file), objects[i]);
                            file.Close();
                        }
                        break;
                    }
                }
            }
        }
        else
        {
            //Debug.Log("Wanted to load objs from " + activeSave);
        }
    }

    // public void InventorySave()
    // {
    //     string contents = "";
    //     for(int i = 0; i < myInventory.myInventory.Count; i++)
    //     {
    //         if(i < myInventory.myInventory.Count - 1)
    //         {
    //             contents += myInventory.myInventory[i] + ",";
    //         }
    //         else
    //         {
    //             contents += myInventory.myInventory[i];
    //         }
    //     }
    //     ItemObject itemsObject = new ItemObject {
    //         inventory = contents,
    //     };
    //     string itemsJson = JsonUtility.ToJson(itemsObject);
    //     Debug.Log("Active save going into SaveItems: " + activeSave);
    //     SaveSystem.SaveItems(itemsJson, activeSave);
    // }

    public void ProgressSave()
    {    
        switch(activeSave)
        {
            case 1:
                // player1Coins = myInventory.coins;
                break;
            case 2:
                // player2Coins = myInventory.coins;
                break;
            case 3:
                // player3Coins = myInventory.coins;
                break;
        }
        SaveObject savedObject = new SaveObject {
            progress = progress1.ToString() + "," + progress2.ToString() + "," + progress3.ToString(),
            name1 = playerName1,
            name2 = playerName2,
            name3 = playerName3,
            p1Coin = player1Coins,
            p2Coin = player2Coins,
            p3Coin = player3Coins,
            genders = player1Gender.ToString() + "," + player2Gender.ToString() + "," + player3Gender.ToString(),
            personality1 = new int[] { playerPersonality1[0], playerPersonality1[1], playerPersonality1[2], playerPersonality1[3], playerPersonality1[4] },
            personality2 = new int[] { playerPersonality2[0], playerPersonality2[1], playerPersonality2[2], playerPersonality2[3], playerPersonality2[4] },
            personality3 = new int[] { playerPersonality3[0], playerPersonality3[1], playerPersonality3[2], playerPersonality3[3], playerPersonality3[4] },
        };
        string savedJson = JsonUtility.ToJson(savedObject);
        Debug.Log(savedJson);
        SaveSystem.SaveProgress(savedJson);
    }

    // public void InventoryLoad()
    // {
    //     string itemString = SaveSystem.LoadItems(activeSave);
    //     if(itemString != null)
    //     {
    //         ItemObject loaded = JsonUtility.FromJson<ItemObject>(itemString);
    //         string[] words = loaded.inventory.Split(',');
    //         for(int i = 0; i < words.Length; i++)
    //         {
    //             if(words[i] == "")
    //             {
    //                 break;
    //             }
    //             myInventory.myInventory.Add(int.Parse(words[i]));
    //         }
    //     }  
    // }

    public void ProgressLoad()
    {
        string progressString = SaveSystem.LoadProgress();
        if(progressString != null)
        {
            //Debug.Log(progressString);
            SaveObject loaded = JsonUtility.FromJson<SaveObject>(progressString);
            string[] progrei = loaded.progress.Split(',');
            progress1 = int.Parse(progrei[0]);
            progress2 = int.Parse(progrei[1]);
            progress3 = int.Parse(progrei[2]);
            playerName1 = loaded.name1;
            playerName2 = loaded.name2;
            playerName3 = loaded.name3;
            player1Coins = loaded.p1Coin;
            player2Coins = loaded.p2Coin;
            player3Coins = loaded.p3Coin;
            string[] gends = loaded.genders.Split(',');
            player1Gender = int.Parse(gends[0]);
            player2Gender = int.Parse(gends[1]);
            player3Gender = int.Parse(gends[2]);
        }

    }

    private class ItemObject {
        public string inventory = "";
    };

    private class SaveObject {
        public string progress = "0,0,0";
        public string name1 = "";
        public string name2 = "";
        public string name3 = "";
        public int p1Coin = 0;
        public int p2Coin = 0;
        public int p3Coin = 0;
        public string genders = "-1,-1,-1";
        public int[] personality1 = new int[] { 50, 50, 50, 50, 50 };
        public int[] personality2 = new int[] { 50, 50, 50, 50, 50 };
        public int[] personality3 = new int[] { 50, 50, 50, 50, 50 };
    };
    
    public void ResetSave()
    {
        Debug.Log(activeSave);
        SaveObject savedObject = new SaveObject {
            progress = "0,0,0",
            name1 = "",
            name2 = "",
            name3 = "",
            p1Coin = 0,
            p2Coin = 0,
            p3Coin = 0,
            genders = "-1,-1,-1",
            personality1 = new int[] { 50, 50, 50, 50, 50 },
            personality2 = new int[] { 50, 50, 50, 50, 50 },
            personality3 = new int[] { 50, 50, 50, 50, 50 },
        };
        switch(activeSave)
        {
            case 1:
            {
                DirectoryInfo dir = new DirectoryInfo(save1Folder);
                FileInfo[] info = dir.GetFiles("*.*");
                foreach (FileInfo f in info)
                {
                    if(f.Extension == ".dat")
                    {
                        File.Delete(f.FullName);
                    }
                }
                savedObject.progress = "0," + progress2.ToString() + "," + progress3.ToString();
                savedObject.genders = "-1," + player2Gender.ToString() + "," + player3Gender.ToString();
                savedObject.name2 = playerName2;
                savedObject.name3 = playerName3;
                savedObject.p2Coin = player2Coins;
                savedObject.p3Coin = player3Coins;
                savedObject.personality1 = new int[] { 50, 50, 50, 50, 50 };
                savedObject.personality2 = new int[] { playerPersonality2[0], playerPersonality2[1], playerPersonality2[2], playerPersonality2[3], playerPersonality2[4] };
                savedObject.personality3 = new int[] { playerPersonality3[0], playerPersonality3[1], playerPersonality3[2], playerPersonality3[3], playerPersonality3[4] };
           break;
            }
            case 2:
            {
                DirectoryInfo dir = new DirectoryInfo(save1Folder);
                FileInfo[] info = dir.GetFiles("*.*");
                foreach (FileInfo f in info)
                {
                    if(f.Extension == ".dat")
                    {
                        File.Delete(f.FullName);
                    }
                }
                savedObject.genders = player1Gender.ToString() + ",-1," + player3Gender.ToString();
                savedObject.progress = progress1.ToString() + ",0," + progress3.ToString();
                savedObject.name1 = playerName1;
                savedObject.name3 = playerName3;
                savedObject.p1Coin = player1Coins;
                savedObject.p3Coin = player3Coins;
                savedObject.personality1 = new int[] { playerPersonality1[0], playerPersonality1[1], playerPersonality1[2], playerPersonality1[3], playerPersonality1[4] };
                savedObject.personality2 = new int[] { 50, 50, 50, 50, 50 };
                savedObject.personality3 = new int[] { playerPersonality3[0], playerPersonality3[1], playerPersonality3[2], playerPersonality3[3], playerPersonality3[4] };            
                break;
            }
            case 3:
            {
                DirectoryInfo dir = new DirectoryInfo(save1Folder);
                FileInfo[] info = dir.GetFiles("*.*");
                foreach (FileInfo f in info)
                {
                    if(f.Extension == ".dat")
                    {
                        File.Delete(f.FullName);
                    }
                }
                savedObject.genders = player1Gender.ToString() + "," + player2Gender.ToString() + ",-1" ;
                savedObject.progress = progress1.ToString() + "," + progress2.ToString() + ",0" ;
                savedObject.name1 = playerName1;
                savedObject.name2 = playerName2;
                savedObject.p1Coin = player1Coins;
                savedObject.p2Coin = player2Coins;
                savedObject.personality1 = new int[] { playerPersonality1[0], playerPersonality1[1], playerPersonality1[2], playerPersonality1[3], playerPersonality1[4] };
                savedObject.personality2 = new int[] { playerPersonality2[0], playerPersonality2[1], playerPersonality2[2], playerPersonality2[3], playerPersonality2[4] };
                savedObject.personality3 = new int[] { 50, 50, 50, 50, 50 }; 
                break;
            }
        }
        //Debug.Log(savedObject);
        string savedJson = JsonUtility.ToJson(savedObject);
        // Deletes inventory data
        SaveSystem.Delete(savedJson, activeSave);
    }
}
