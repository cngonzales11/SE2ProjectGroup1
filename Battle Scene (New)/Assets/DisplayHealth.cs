using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayHealth : MonoBehaviour {
    public GameObject character;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<UnityEngine.UI.Text>().text = (character.GetComponent<Character>().hp).ToString();
	}
}
