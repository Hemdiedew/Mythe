using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 6f;
    [SerializeField] private Vector3 moveDirection = Vector3.zero;
    private bool _canMove = true;
    
    [Header("Sprinting")]
    [SerializeField] private float sprintAmplifier = 2;
    [SerializeField] private bool _canSprint = true;
    private bool _isSprinting = false;

    [Header("Gravity")]
    [SerializeField] private float gravity = 20f;
    
    [Header("Jumping")]
    [SerializeField] private float jumpSpeed = 8f;
    [SerializeField] private int maxDoubleJumps = 2;
    private int jumps;

    [Header("Connections")]
    [SerializeField] private CharacterController controller;
    [SerializeField] private Animator anim;

    //background variables
    private float _moveHor;
    private float _moveVer;

    private void Update()
    {
        _moveHor = Input.GetAxis("Horizontal");
        _moveVer = Input.GetAxis("Vertical"); 
        Move();
    }

    public void Move()
    {
        if (_canMove == false) return;
        if(!_isSprinting) _isSprinting = Input.GetKeyDown(KeyCode.LeftControl);
        
        if (controller.isGrounded)
        {
            moveDirection = new Vector3((_moveHor / 2) * (_isSprinting ?  sprintAmplifier : 1), 0, _moveVer * (_isSprinting ? sprintAmplifier : 1));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetKey(KeyCode.Space))
            {
                moveDirection.y = jumpSpeed;
            }
            jumps = 0;
        } 
        else
        {
            moveDirection = new Vector3((_moveHor / 2) * (_isSprinting ? sprintAmplifier : 1), moveDirection.y, _moveVer * (_isSprinting ? sprintAmplifier : 1));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection.x *= speed;
            moveDirection.z *= speed;
            if (Input.GetKeyDown(KeyCode.Space) && jumps < maxDoubleJumps)
            {
                moveDirection.y = jumpSpeed;
                jumps++;
            }
        }
        
        if (_moveVer == 0 && _moveHor == 0) _isSprinting = false;
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }


}
