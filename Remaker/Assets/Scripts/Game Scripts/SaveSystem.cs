using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveSystem
{
    public static readonly string save1Folder = Application.persistentDataPath + "/Save1/";
    public static readonly string save2Folder = Application.persistentDataPath + "/Save2/";
    public static readonly string save3Folder = Application.persistentDataPath + "/Save3/";
    public static readonly string saveFolder = Application.persistentDataPath + "/Saves/";

    public static void SaveItems(string itemString, int save)
    {
        string myFolder;
        switch(save)
        {
            case 1:
                myFolder = save1Folder;
                break;
            case 2:
                myFolder = save2Folder;
                break;
            case 3:
                myFolder = save3Folder;
                break;
            default:
                Debug.Log("Save # not recognized.");
                return;
        }
        Directory.CreateDirectory(myFolder);
        File.WriteAllText(myFolder + "/savedItems.txt", itemString);   
    }
    
    public static void SaveProgress(string saveString)
    {
        Directory.CreateDirectory(saveFolder);
        File.WriteAllText(saveFolder + "/savedProgress.txt", saveString);
    }

    public static string LoadItems(int save)
    {
        string myFolder;
        switch(save)
        {
            case 1:
                myFolder = save1Folder;
                break;
            case 2:
                myFolder = save2Folder;
                break;
            case 3:
                myFolder = save3Folder;
                break;
            default:
                //Debug.Log("Load # not recognized.");
                return null;
        }
        if(File.Exists(myFolder + "/savedItems.txt"))
        {
            string rawItems = File.ReadAllText(myFolder + "/savedItems.txt");
            return rawItems;
        }
        else
        {
            Debug.Log("No save item.");
            return null;
        }
    }

    public static string LoadProgress()
    {
        if(File.Exists(saveFolder + "/savedProgress.txt"))
        {
            string rawSaved = File.ReadAllText(saveFolder + "/savedProgress.txt");
            return rawSaved;
        }
        else
        {
            Debug.Log("No save info.");
            return null;
        }
    }

    public static void Delete(string saveString, int save)
    {
        string myFolder;
        switch(save)
        {
            case 1:
                myFolder = save1Folder;
                break;
            case 2:
                myFolder = save2Folder;
                break;
            case 3:
                myFolder = save3Folder;
                break;
            default:
                Debug.Log("Delete save  # not recognized.");
                return;
        }
        if(File.Exists(myFolder + "/savedItems.txt"))
        {
            File.Delete(myFolder + "/savedItems.txt");
        }
        if(File.Exists(saveFolder + "/savedProgress.txt"))
        {
            Debug.Log("Writing save");
            Debug.Log(saveString);
            File.WriteAllText(saveFolder + "/savedProgress.txt", saveString);
        }
    }
}
