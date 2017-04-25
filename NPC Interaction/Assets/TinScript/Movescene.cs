using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Movescene : MonoBehaviour {

    public string loadLevel;
	//load a scene when Player collide with another object.
	void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(loadLevel);
        }
    }
}
