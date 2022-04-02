using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float
        checkRadius,
        moveSpeed;

     [SerializeField] private float
        jumpTime,
        jumpForce;

    private float
        maxMoveSpeed = 10f,
        baseMoveSpeed = 0.7f,
        acceleration = 1f,
        jumpTimeCounter;

    private bool
        isJumping,
        isGrounded;
    [SerializeField]
    private Transform feetPosition;
    [SerializeField]
    private LayerMask whatIsGround;
    
    void Start()
    {
        Debug.Log("Start");
        rb = gameObject.GetComponent<Rigidbody2D>();
        moveSpeed = baseMoveSpeed;
    }

    private void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        Run();
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

        if (directionX > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }else if (directionX < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    private void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(feetPosition.position, checkRadius, whatIsGround);
        if (isGrounded == true && Input.GetKeyDown(KeyCode.W))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = new Vector2(rb.velocity.x, 1f * jumpForce);
        }

        if (Input.GetKey(KeyCode.W))
        {
            if (jumpTimeCounter > 0 && isJumping == true)
            {
                rb.velocity = new Vector2(rb.velocity.x, 1f * jumpForce);
                jumpTimeCounter -= Time.deltaTime; 
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            isJumping = false;
        }
    }
    
    
}
