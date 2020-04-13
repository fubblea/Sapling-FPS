using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{

    [SerializeField] float gravity = 6;
    [SerializeField] float walkSpeed = 4;
    [SerializeField] float sprintSpeed = 6;

    float moveSpeed;
    Vector3 moveDirection;
    
    CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(moveX, 0, moveZ);
            moveDirection *= moveSpeed;

            if (Input.GetKey(KeyCode.LeftShift) && moveZ == 1)
            {
                moveSpeed = sprintSpeed;
            }
            else
            {
                moveSpeed = walkSpeed;
            }
        }

        moveDirection.y -= gravity;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
