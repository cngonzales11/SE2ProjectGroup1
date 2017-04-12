using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMove : MonoBehaviour {
    public int move;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void selectMove()
    {
        Debug.Log("Selecting a Move");

        switch(move)
        {
            case 1:
                battleSystem.getInstance().selectMove1();
                break;
            case 2:
                battleSystem.getInstance().selectMove2();
                break;
            case 3:
                battleSystem.getInstance().selectMove3();
                break;
            case 4:
                battleSystem.getInstance().selectMove4();
                break;
        }
    }
}
