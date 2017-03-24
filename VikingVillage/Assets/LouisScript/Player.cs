using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float movementSpeed = 10;

    public bool canMove;

    void Update()
    {
        if (!canMove)
        {
            return;
        }

        float horizontal = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        transform.Translate(horizontal, 0, 0);

        float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        transform.Translate(0, 0, vertical);
    }

}
