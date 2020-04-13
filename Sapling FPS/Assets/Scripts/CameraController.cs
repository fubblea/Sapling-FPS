using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player, playerArms;
    [SerializeField] float mouseSensitivity = 3;

    float xAxisClamp = 0;

    private void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;

        RotateCamera();
    }

    private void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        float rotX = mouseX * mouseSensitivity;
        float rotY = mouseY * mouseSensitivity;

        xAxisClamp -= rotY;

        Vector3 rotPlayerArms = playerArms.transform.rotation.eulerAngles;
        Vector3 rotPlayer = player.transform.rotation.eulerAngles;

        rotPlayerArms.x -= rotY;
        rotPlayerArms.z = 0;
        rotPlayer.y += rotX;

        if(xAxisClamp > 90)
        {
            xAxisClamp = 90;
            rotPlayerArms.x = 90;
        }
        else if (xAxisClamp < -90)
        {
            xAxisClamp = -90;
            rotPlayerArms.x = 270;
        }

        playerArms.rotation = Quaternion.Euler(rotPlayerArms);
        player.rotation = Quaternion.Euler(rotPlayer);

    }
}
