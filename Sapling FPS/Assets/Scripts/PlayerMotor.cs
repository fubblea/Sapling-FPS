using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{

    [SerializeField] float moveSpeed = 4;
    [SerializeField] float gravity = 6;

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
        }

        moveDirection.y -= gravity;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
