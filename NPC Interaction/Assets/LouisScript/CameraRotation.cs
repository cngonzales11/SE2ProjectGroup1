using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{

    public Player target;
    public float rotateSpeed = 5;
    Vector3 offset;

    void Start()
    {
        target = FindObjectOfType<Player>();
        offset = target.transform.position - transform.position;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        if (!target.canMove)
        {
            return;
        }

        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        target.transform.Rotate(0, horizontal, 0);

        float desiredAngle = target.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        transform.position = target.transform.position - (rotation * offset);

        transform.LookAt(target.transform);
    }

}
