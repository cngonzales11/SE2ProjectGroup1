using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    public Transform canvas;
    void Update()
    {

        Pause();
    }
    public void Pause()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (canvas.gameObject.activeInHierarchy == false)
            {
                canvas.gameObject.SetActive(true);
                Time.timeScale = 0;
             
            }
            else
            {
                canvas.gameObject.SetActive(false);
                Time.timeScale = 1;
          
            }
        }
    }
}
