using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    GameObject invetoryPanel;
    GameObject slotPanel;
    public GameObject inventorySlot;
    public GameObject invetoryItem;
    ItemDatabase database;

    int slotAmount;
    public List<Items> items = new List<Items>();
    public List<GameObject> slots = new List<GameObject>();

    void Start()
    {
        database = GetComponent<ItemDatabase>();
        slotAmount = 16;
        invetoryPanel = GameObject.Find("Inventory Panel");
        slotPanel = invetoryPanel.transform.FindChild("Slot Panel").gameObject;

        for(int i = 0; i< slotAmount; i++)
        {
            items.Add(new Items());
            slots.Add(Instantiate(inventorySlot));
            slots[i].transform.SetParent(slotPanel.transform);
        }
        AddItem(0);
       
    }

    public void AddItem(int id)
    {
        Items itemToAdd = database.FetchItemById(id);
        for(int i = 0; i < items.Count;i++)
        {
            if(items[i].ID == -1)
            {
                items[i] = itemToAdd;
                GameObject itemObj = Instantiate(invetoryItem);
                itemObj.transform.SetParent(slots[i].transform);
                itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite;
                itemObj.transform.position = Vector2.zero;
                itemObj.name = itemToAdd.Title;
                break;
            }
        }
    }
}
