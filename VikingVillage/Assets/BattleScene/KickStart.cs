using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickStart : MonoBehaviour {
    public GameObject player;
	// Use this for initialization
	void Start () {
        battleSystem.getInstance().setCurrentPlayer(player);
        battleSystem.getInstance().Start();
    }
	
	// Update is called once per frame
	void Update () {
        battleSystem.getInstance().Update();
	}
}
