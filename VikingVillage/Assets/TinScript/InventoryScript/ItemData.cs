using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

        public Items item;
        public int amount;
        public int slotID;

        
        private Inventory inventory;
        private Vector2 offset;
    

    void Start()
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if(item != null)
        {
            offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);
            this.transform.SetParent(this.transform.parent.parent);
            this.transform.position = eventData.position - offset;
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            this.transform.position = eventData.position - offset;
            
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        this.transform.SetParent(inventory.slots[slotID].transform);
        this.transform.position = inventory.slots[slotID].transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
