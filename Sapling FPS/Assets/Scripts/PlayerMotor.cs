using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{

    [SerializeField] float gravity = 6;
    [SerializeField] float walkSpeed = 4;
    [SerializeField] float sprintSpeed = 6;
    [SerializeField] float jumpSpeed = 40;

    float moveSpeed;
    Vector3 moveDirection;
    
    CharacterController controller;
    Animator anim;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        Move();
        Attack();
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetTrigger("attackTrigger");
        }
    }

    private void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(moveX, 0, moveZ);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= moveSpeed;

            WalkAnim(moveZ);
            Sprint(moveZ);
            Jump();
        }

        moveDirection.y -= gravity;
        controller.Move(moveDirection * Time.deltaTime);
    }

    private void WalkAnim(float moveZ)
    {
        if (moveZ != 0 && !Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetInteger("moveCondition", 1);
        }
        if (moveZ == 0)
        {
            anim.SetInteger("moveCondition", 0);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            moveDirection.y += jumpSpeed;
            anim.SetTrigger("jumpTrigger");
        }
    }

    private void Sprint(float moveZ)
    {
        if (Input.GetKey(KeyCode.LeftShift) && moveZ == 1)
        {
            moveSpeed = sprintSpeed;
            anim.SetInteger("moveCondition", 2);
        }
        else
        {
            moveSpeed = walkSpeed;
        }
    }
}
