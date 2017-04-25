using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextImporter : MonoBehaviour {

    
    
    // Use this for initialization
	public static string[] ImportText(TextAsset textFile)
    {
        string[] textLines;
	
        textLines = (textFile.text.Split('\n'));
        return textLines;        	
	}
	
}
