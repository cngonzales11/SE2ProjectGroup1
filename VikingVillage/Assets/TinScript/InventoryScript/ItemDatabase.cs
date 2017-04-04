using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;


public class ItemDatabase : MonoBehaviour
{
    
    private List<Items> database = new List<Items>();
    private JsonData itemData;

    void Start()
    {
        
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Item.json"));
        ConstructItemDatabase();

        Debug.Log(database[0].Slug);
       
    }
    public Items FetchItemById(int id)
    {
        for (int i = 0; i < database.Count; i++)
            if (database[i].ID == id)
                return database[i];
        return null;

    }
    void ConstructItemDatabase()
    {
        for (int i = 0; i < itemData.Count; i++)
        {
            database.Add(new Items((int)itemData[i]["id"], itemData[i]["title"].ToString(), (int)itemData[i]["value"], (int)itemData[i]["damageMin"], (int)itemData[i]["damageMax"], itemData[i]["description"].ToString(), itemData[i]["slug"].ToString(), (bool)itemData[i]["stackable"]));
        }
    }
}

