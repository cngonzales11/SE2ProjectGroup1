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
        tooltip = GameObject.Find("tooltip");
        tooltip.SetActive(false);
    }

    void Update()
    {
        if(tooltip.activeSelf)
        {
            tooltip.transform.position = Input.mousePosition;
        }
    }
	// Use this for initialization
    public void Activate(Items item)
    {
        this.item = item;
        ConstructDataString();
        tooltip.SetActive(true);
    }

    public void Deactivate()
    {
        tooltip.SetActive(false);
    }

    public void ConstructDataString()
    {
        data = item.Title;
        tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
    }
}
