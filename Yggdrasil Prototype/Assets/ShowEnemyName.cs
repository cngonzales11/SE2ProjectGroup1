using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowEnemyName : MonoBehaviour {
    private Character enemy;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        enemy = battleSystem.getInstance().Tar;

        if (enemy)
        {
            gameObject.GetComponent<UnityEngine.UI.Text>().text = enemy.name;
        }

        else
        {
            gameObject.GetComponent<UnityEngine.UI.Text>().text = "FIGHT!";
        }
	}
}
