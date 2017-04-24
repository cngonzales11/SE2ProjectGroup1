using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour {
    private Items item;
    private string data;
    private GameObject tooltip;

    void Start()
    {
        //find game object Tooltip
        tooltip = GameObject.Find("tooltip");
        //set tooltip to invisible
        tooltip.SetActive(false);
    }

    void Update()
    {
        //place Tooltip display to mouse position
        if(tooltip.activeSelf)
        {
            tooltip.transform.position = Input.mousePosition;
        }
    }
	//when hovering over item display tooltip
    public void Activate(Items item)
    {
        this.item = item;
        ConstructDataString();
        tooltip.SetActive(true);
    }
    //when hoving away from item make tooltip invisible
    public void Deactivate()
    {
        tooltip.SetActive(false);
    }
    //Create tool text with item data.
    public void ConstructDataString()
    {
        data = item.Title + "\n" + item.DamageMin + "-" + item.DamageMax;
        tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
    }
}
