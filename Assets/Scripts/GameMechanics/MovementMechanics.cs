﻿using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Rigidbody2D))]

public class MovementMechanics : MonoBehaviour {
    public float walkSpeed = 2;
    public float runSpeed = 5;
    public float acceleration = 15;
    public float runThreshold = .45f;//The amount that has to be input before the character will enter run speed
    public bool inputActive = true;
    public bool movementActive = true;

    float hInput;//The input and direction that the character should move in
    float currentSpeed;
    Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!movementActive) return;
        if (!inputActive)
        {
            hInput = 0;
        }
        float scale = (hInput < 0) ? -1 : 1;
        currentSpeed = 0;
        if (Mathf.Abs(hInput) > runThreshold)
        {
            currentSpeed = scale * runSpeed;
        }   
        else if (Mathf.Abs(hInput) > 0.01f)
        {
            currentSpeed = scale * walkSpeed;
        }
    }

    public void setHorizontalInput(float hInput)
    {
        this.hInput = hInput;
    }

    void FixedUpdate()
    {
        rigid.velocity = Vector2.MoveTowards(rigid.velocity, new Vector2(currentSpeed, rigid.velocity.y), acceleration * Time.fixedDeltaTime);
    }
}
