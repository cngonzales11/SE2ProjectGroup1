using UnityEngine;

public class PauseGame : MonoBehaviour {

    // Use this for initialization
    public Transform canvas;
    public Transform Player;



    // Update is called once per frame
    void Update ()
    {

        Pause();
    }
    public void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (canvas.gameObject.activeInHierarchy == false)
            {
                canvas.gameObject.SetActive(true);
                Time.timeScale = 0;
                Player.GetComponent<Player>().enabled = false;
            }
            else
            {
                canvas.gameObject.SetActive(false);
                Time.timeScale = 1;
                Player.GetComponent<Player>().enabled = true;
            }
        }
    }
}
