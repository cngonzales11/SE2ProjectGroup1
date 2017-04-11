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
            slots[i].GetComponent<Slot>().slotId = i;
            slots[i].transform.SetParent(slotPanel.transform);
        }
        AddItem(0);
        AddItem(1);

    }

    public void AddItem(int id)
    {

        Items itemToAdd = database.FetchItemById(id);
        if (itemToAdd.Stackable && CheckItemExsist(itemToAdd))
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == id)
                {
                    ItemData data = slots[i].transform.GetChild(0).GetComponent<ItemData>();
                    data.amount++;
                    data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
                  
                }
            }
        }
        else
        {

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == -1)
                {
                    items[i] = itemToAdd;
                    GameObject itemObj = Instantiate(invetoryItem);
                    itemObj.GetComponent<ItemData>().item = itemToAdd;
                    itemObj.GetComponent<ItemData>().slotID = i;
                    itemObj.transform.SetParent(slots[i].transform);
                    itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite;
                    itemObj.transform.position = Vector2.zero;
                    itemObj.name = itemToAdd.Title;
                    break;
                }
            }
        }
    }

    bool CheckItemExsist(Items item)
    {
        for (int i = 0; i < items.Count; i++)
        { 
            if (items[i].ID == item.ID)
                return true;
       }
        return false;
    }
}
