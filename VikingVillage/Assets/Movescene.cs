using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Movescene : MonoBehaviour {

    [SerializeField] private string loadLevel;
	
	void OnTriggerEmter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(loadLevel);        }
    }
}
