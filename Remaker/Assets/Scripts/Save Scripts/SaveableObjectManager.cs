using System.Collections;
using System.Collections.Generic;
using Microsoft.SqlServer.Server;
using UnityEngine;

public class SaveableObjectManager : MonoBehaviour
{
    public static SaveableObjectManager Instance { get; private set; }

    ///////////////////////////////////////////////////////////////////
    /* CHEST SAVING */
    ///////////////////////////////////////////////////////////////////
    
    private List<Chest> chests = new List<Chest>();

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public List<ChestData> GatherChestData()
    {
        List<ChestData> chestDataList = new List<ChestData>();
        foreach(Chest chest in chests)
        {
            ChestData data = new ChestData {
                objectId = chest.chestId,
                isOpen = chest.IsOpen()
            };
            chestDataList.Add(data);
        }
        return chestDataList;
    }

    public void RestoreChestData(List<ChestData> chestDataList)
    {
        foreach(ChestData chestData in chestDataList)
        {
            Chest chest = chests.Find(c => c.chestId == chestData.objectId);
            if(chest != null && chestData.isOpen)
            {
                chest.QuietOpen();
            }
        }
    }

    public void RegisterChest(Chest chest)
    {
        if(!chests.Contains(chest))
        {
            chests.Add(chest);
        }
    }

    public void UnregisterChest(Chest chest)
    {
        if(chests.Contains(chest))
        {
            chests.Remove(chest);
        }
    }

    public List<Chest> GetAllChests()
    {
        return chests;
    }
}
