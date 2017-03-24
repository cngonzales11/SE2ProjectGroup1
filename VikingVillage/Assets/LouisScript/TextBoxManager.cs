﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {

    public GameObject textBox;

    public Text theText;

    public TextAsset textFile;
    public string[] textLines;
    public int currentLine;
    public int endAtLine;

    public Player player;

    public bool isActive;

    public bool stopPlayerMovement;

    // Use this for initialization
    void Start()
    {

        player = FindObjectOfType<Player>();

        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }

        if(endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }

        if (isActive)
        {
            EnableTextBox();
        } else
        {
            DisableTextBox();
        }

    }

    void Update()
    {
        if (!isActive)
        {
            return;
        }

        theText.text = textLines[currentLine];

        if (Input.GetKeyDown(KeyCode.Return))
        {
            currentLine++;
        }

        if(currentLine > endAtLine)
        {
            DisableTextBox();
        }
    }

    public void EnableTextBox()
    {
        textBox.SetActive(true);
        isActive = true;

        if (stopPlayerMovement)
        {
            player.canMove = false;
        }
    }

    public void DisableTextBox()
    {
        textBox.SetActive(false);
        isActive = false;

        player.canMove = true;
    }

    public void ReloadScript(TextAsset newText)
    {
        if(newText != null)
        {
            textLines = new string[1];
            textLines = (newText.text.Split('\n'));
        }
    }
}
