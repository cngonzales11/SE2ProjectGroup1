using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {
   public GameObject character;

    

    public bool isFilled()
    {
        if (character == null) return false;

        return true;
    }

	// Use this for initialization
	void Start () {
 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
