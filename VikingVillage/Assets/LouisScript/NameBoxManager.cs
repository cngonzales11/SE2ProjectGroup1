using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameBoxManager : MonoBehaviour {

    public TextBoxManager manager;
    public TextAsset textFile;
    public GameObject textBox;
    public Text text;
    public string[] textLines;
    public int readLine;

    public bool isActive;

    // Use this for initialization
    void Start ()
    {
        manager = FindObjectOfType<TextBoxManager>();

        if (textFile != null)
        {
            LoadText(textFile);
        }

        if (manager.isActive)
        {
            EnableTextBox();
        } else
        {
            DisableTextBox();
        }

    }
	
	// Update is called once per frame
	void Update ()
    {
        text.text = textLines[readLine];

        if (manager.isActive)
        {
            EnableTextBox();
        } else
        {
            DisableTextBox();
        }
	}

    public void EnableTextBox()
    {
        textBox.SetActive(true);
        isActive = true;
    }

    public void DisableTextBox()
    {
        textBox.SetActive(false);
        isActive = false;
    }

    public void LoadText(TextAsset textFile)
    {
        textLines = TextImporter.ImportText(textFile);

    }
}
