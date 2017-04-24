using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

//item database that read a json file then convert to a c# object
public class ItemDatabase : MonoBehaviour
{
    
    private List<Items> database = new List<Items>();
    private JsonData itemData;

    void Start()
    {
        //read json file 
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Item.json"));
        //make database
        ConstructItemDatabase();

       
       
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

