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

    void Start()
    {
        player = FindObjectOfType<Player>();
        //get database
        database = GetComponent<ItemDatabase>();
        //slot maxium amount
        slotAmount = 16;
        //game object inventory panel
        invetoryPanel = GameObject.Find("PlayerInventoryPanel");
        //game object slot panel
        slotPanel = invetoryPanel.transform.FindChild("Slot Panel").gameObject;

        for(int i = 0; i< slotAmount; i++)
        {
            items.Add(new Items());
            slots.Add(Instantiate(inventorySlot));
            slots[i].GetComponent<Slot>().slotId = i;
            slots[i].transform.SetParent(slotPanel.transform);
        }

        AddItem(1);

        if (isActive)
        {
            EnableTextBox();
        }
        else
        {
            DisableTextBox();
        }
    }

    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!isActive)
            {
                EnableTextBox();
            }
            else
            {
                DisableTextBox();
            }
        }

    }

    //Add item and check if the item is stackable.
    public void AddItem(int id)
    {

        Items itemToAdd = database.FetchItemById(id);
        //check if item is already there and if it is stackable
        //if stackable add to the data show item stack.
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
    //check if Item exists
    bool CheckItemExsist(Items item)
    {
        for (int i = 0; i < items.Count; i++)
        { 
            if (items[i].ID == item.ID)
                return true;
       }
        return false;
    }

    public void EnableTextBox()
    {
        invetoryPanel.SetActive(true);
        isActive = true;

        if (stopPlayerMovement)
        {
            player.canMove = false;
        }
    }

    public void DisableTextBox()
    {
        invetoryPanel.SetActive(false);
        isActive = false;

        player.canMove = true;
    }

}
