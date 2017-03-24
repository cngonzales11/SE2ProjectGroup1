using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAction : MonoBehaviour {
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray toMouse = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rhInfo;
            float distance = 500.0f;
            bool didHit = Physics.Raycast(toMouse, out rhInfo, distance);

            if (didHit)
            {
                if (rhInfo.collider.tag == "tile")
                {
                    Tile tileScript = rhInfo.collider.GetComponent<Tile>();

                    if (tileScript)
                    {
                        GameObject targeted = tileScript.character;
                        Character tar = targeted.GetComponent<Character>();

                        if(tar != null && battleSystem.getInstance().hasCurrentMove()) 
                        {
                            Debug.Log(tar.maxHp);
                            battleSystem.getInstance().setTarget(tar);
                        }
                    }
                }
            }

            else
            {
                Debug.Log("Did not click on an object");
            }
        }

    }
}
