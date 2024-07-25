using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform player;

    public float distance;
    public float pitch;
    public float yaw;

    // Start is called before the first frame update
    void Start()
    {
        this.distance = 10;
        this.pitch = 45;
        this.yaw = 45;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            float dX = Input.GetAxis("Mouse X") * 10f;
            float dY = Input.GetAxis("Mouse Y") * 10f;
            this.pitch -= dY;
            this.yaw += dX;
            if (this.pitch < 0)
                this.pitch = 0;
            else if (this.pitch > 90)
                this.pitch = 90;
        }
        float scrollInput = -Input.mouseScrollDelta.y;
        float targetDistance = this.distance + Time.deltaTime * scrollInput * 1000f;
        if (targetDistance > 50)
        {
            targetDistance = 50;
        }
        else if (targetDistance <= 10f)
            targetDistance = 10;
        this.distance = targetDistance;

        float horizontalDistance = this.distance * Mathf.Cos(Mathf.Deg2Rad * this.pitch);
        float verticalDistance = this.distance * Mathf.Sin(Mathf.Deg2Rad * this.pitch);

        Vector3 newPos = this.player.position;
        newPos.y += verticalDistance;
        newPos.x += horizontalDistance * Mathf.Sin(Mathf.Deg2Rad * this.yaw);
        newPos.z += horizontalDistance * Mathf.Cos(Mathf.Deg2Rad * this.yaw);

        this.transform.position = newPos;
        this.transform.LookAt(this.player.position);
    }
}
