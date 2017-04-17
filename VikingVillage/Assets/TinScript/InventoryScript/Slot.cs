using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    private Inventory inventory;

    public int slotId;
    
    void Start()
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData>();
        if (inventory.items[slotId].ID == -1)
        {
            inventory.items[droppedItem.slotID] = new Items();
            inventory.items[slotId] = droppedItem.item;
            droppedItem.slotID = slotId;
        }
        else if(droppedItem.slotID != slotId)
        {
            Transform item = this.transform.GetChild(0);
            item.GetComponent<ItemData>().slotID = droppedItem.slotID;
            item.transform.SetParent(inventory.slots[droppedItem.slotID].transform);
            item.transform.position = inventory.slots[droppedItem.slotID].transform.position;

            droppedItem.slotID = slotId;
            droppedItem.transform.SetParent(this.transform);
            droppedItem.transform.position = this.transform.position;

            inventory.items[droppedItem.slotID] = item.GetComponent<ItemData>().item;
            inventory.items[slotId] = droppedItem.item;
        }
    }
}
