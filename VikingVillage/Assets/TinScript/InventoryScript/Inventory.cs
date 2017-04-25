using System;
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

    public bool isActive;
    public bool stopPlayerMovement;
    public Player player;
    public TextAsset textFile;
    private string[] textlines;

    void Start()
    {
        //get database
        database = GetComponent<ItemDatabase>();
        //slot maxium amount
        slotAmount = 16;
        //game object inventory panel
        invetoryPanel = GameObject.Find("PlayerInventoryPanel");
        //game object slot panel
        slotPanel = invetoryPanel.transform.FindChild("Slot Panel").gameObject;
        //read from a text file
        textlines = TextImporter.ImportText(textFile);
        //create each item in a slot 
        for (int i = 0; i < slotAmount; i++)
        {
            items.Add(new Items());
            slots.Add(Instantiate(inventorySlot));
            slots[i].GetComponent<Slot>().slotId = i;
            slots[i].transform.SetParent(slotPanel.transform);
        }

        //read from file then add to iventory
        for (int i = 0; i < textlines.Length; i++)
        {
            AddItem(int.Parse(textlines[i]));
        }
        //disable and enable invetory canvas
        if (isActive)
        {
            EnabledInventoryPanel();
        }
        else
        {
            DisableInventoryPanel();
        }
    }

    //keyboard toggle I to disable and enable inventory panel
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            if (!isActive)
            {
                EnabledInventoryPanel();
            }
            else
            {
                DisableInventoryPanel();
            }
        }
    }
    
    //Add item and check if the item is stackable.
    public void AddItem(int id)
    {

        Items itemToAdd = database.FetchItemById(id);
        //check if item is already there and if it is stackable
        //if stackable add to the data show item stack.
        if (itemToAdd.Stackable && CheckItem(itemToAdd))
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
        //else make new item in new slots.
        else
        {

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == -1)
                {
                    items[i] = itemToAdd;
                    GameObject itemObj = Instantiate(invetoryItem);
                    itemObj.GetComponent<ItemData>().item = itemToAdd;
                    itemObj.GetComponent<ItemData>().amount = 1;
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
    //check is item exsist
    bool CheckItem(Items item)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].ID == item.ID)
                return true;
        }
        return false;
    }
    //show invetory panel
    public void EnabledInventoryPanel()
    {
        invetoryPanel.SetActive(true);
        isActive = true;

        if (stopPlayerMovement)
        {
            player.canMove = false;
        }
    }
    //disable inventory panel
    public void DisableInventoryPanel()
    {
        invetoryPanel.SetActive(false);
        isActive = false;

        player.canMove = true;
    }


}
