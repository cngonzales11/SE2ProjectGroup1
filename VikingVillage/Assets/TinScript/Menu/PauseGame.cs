using UnityEngine;

public class PauseGame : MonoBehaviour {

    // Use this for initialization
    public Transform canvas;
    public Transform Player;



    // Update is called once per frame
    void Update ()
    {
        //pause the game when menu is open
        Pause();
    }
    public void Pause()
    {
        //when hitting Esc Key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //when menu is not displace 
            if (canvas.gameObject.activeInHierarchy == false)
            {
                //Display menu
                canvas.gameObject.SetActive(true);
                //freeze time scale
                Time.timeScale = 0;
                //Freeze Player
                Player.GetComponent<Player>().enabled = false;
            }
            else
            {
                //turn menu off
                canvas.gameObject.SetActive(false);
                Time.timeScale = 1;//return time scale back
                //player can move again
                Player.GetComponent<Player>().enabled = true;
            }
        }
    }
}
