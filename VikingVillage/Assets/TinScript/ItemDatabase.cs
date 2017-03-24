using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;


public class ItemDatabase : MonoBehaviour
{
    
    private List<Item> database = new List<Item>();
    private JsonData itemData;

    void Start()
    {
        
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Item.json"));
        ConstructItemDatabase();

        Debug.Log(FetchItemById(0).Description);
    }
    public Item FetchItemById(int id)
    {
        for (int i = 0; i < database.Count; i++)
            if (database[i].ID == id)
                return database[i];
        return null;

    }
    void ConstructItemDatabase()
    {
        for(int i = 0; i < itemData.Count;i++)
        {
            database.Add(new Item((int)itemData[i]["id"],itemData[i]["title"].ToString(),(int)itemData[i]["value"],(int)itemData[i]["damageMin"],(int)itemData[i]["damageMax"],itemData[i]["description"].ToString()));
        }
    }
}


public class Item
{
    public int ID { get; set; }
    public string Title { get; set; }
    public int Value { get; set; }
    public int DamageMin { get; set; }
    public int DamageMax { get; set; }
    public string Description { get; set; }

    public Item(int id, string title, int value, int damageMIn, int damageMax, string description)
    {
        this.ID = id;
        this.Title = title;
        this.Value = value;
        this.DamageMin = damageMIn;
        this.DamageMax = DamageMax;
        this.Description = description;
    }
}