using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float
        moveSpeed,
        jumpSpeed;

    private float
        maxMoveSpeed = 10f,
        baseMoveSpeed = 0.7f,
        acceleration = 1f;
    void Start()
    {
        Debug.Log("Start");
        rb = gameObject.GetComponent<Rigidbody2D>();
        moveSpeed = baseMoveSpeed;
    }
    
    private void Awake()
    {
        
    }

    

    private void FixedUpdate()
    {
        Run();
        Jump();
        
    }
    
    
    private void Run()
    {
        float directionX = Input.GetAxisRaw("Horizontal");

        if (directionX == 0)
        {
            moveSpeed = baseMoveSpeed;
        }
        if (moveSpeed < maxMoveSpeed)
        {
            moveSpeed += acceleration;
            rb.velocity = new Vector2(directionX * moveSpeed, rb.velocity.y);
        }else if (moveSpeed >= maxMoveSpeed)
        {  
            rb.velocity = new Vector2(directionX * maxMoveSpeed, rb.velocity.y);
        }
        
        
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
    }
}
