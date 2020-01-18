﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 1;

    private CharacterController controller;
    private Vector3 forward;
    private Vector3 moveDirection;

    private float h, v;
    private Vector3 lastDirection;

    private Animator animator;
    private AnimatorClipInfo currentAnimation;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        lastDirection = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        currentAnimation = animator.GetCurrentAnimatorClipInfo(0)[0];
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");

        moveDirection.z = v * Speed * Time.deltaTime;
        moveDirection.x = h * Speed * Time.deltaTime;

        //transform.Rotate(Vector3.forward * h * Time.deltaTime);

        transform.rotation = Quaternion.LookRotation(moveDirection.magnitude != 0 ? moveDirection : lastDirection);

        animator.SetFloat("Speed", moveDirection.magnitude);

        controller.Move(moveDirection);
        lastDirection = moveDirection.magnitude != 0 ? moveDirection : lastDirection;
    }
}