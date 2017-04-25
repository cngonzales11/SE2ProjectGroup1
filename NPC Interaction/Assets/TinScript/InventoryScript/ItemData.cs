using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler,IPointerExitHandler
{

        public Items item;
        public int amount;
        public int slotID;

        
        private Inventory inventory;
        private ToolTip tooltip;
        private Vector2 offset;
    

    void Start()
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        tooltip = inventory.GetComponent<ToolTip>();
    }
    //if item is not null allow drag item
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
    //item not null is being drag
    public void OnDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            this.transform.position = eventData.position - offset;
            
        }
    }
    //when end drag set to new postion if slot is available. Or reset back to original position.
    public void OnEndDrag(PointerEventData eventData)
    {

        this.transform.SetParent(inventory.slots[slotID].transform);
        this.transform.position = inventory.slots[slotID].transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
    //activate tooltip when mouse hover over item
    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltip.Activate(item);   
    }
    //stop tooltip when mouse exit
    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.Deactivate();
    }
}
