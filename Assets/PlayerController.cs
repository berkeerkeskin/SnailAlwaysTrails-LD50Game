using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    private Rigidbody2D playerRigidbody2D;
    private CapsuleCollider2D capsuleCollider2D;
    private float horizontalDirection;
    public float speed = 1f;
    void Start()
    {
        Debug.Log("Start");
    }
    
    private void Awake()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalDirection = Input.GetAxisRaw("Horizontal");

        Vector3 characterScale = transform.localScale;

        if (Input.GetAxisRaw("Horizontal") < 0)
        { characterScale.x = -1;
        }

        if (Input.GetAxisRaw("Horizontal") > 0)
        { 
            characterScale.x = 1;
        }

        transform.localScale = characterScale;
        
        float moveDirection = 0;
        if (Mathf.Abs(horizontalDirection) >= 0.0001f)
            moveDirection =  0.9f;
    }

    private void FixedUpdate()
    {
        HandleMovement();
        
    }
    
    
    private void HandleMovement()
    {
            playerRigidbody2D.velocity += new Vector2(horizontalDirection *speed, 0f);
            //playerRigidbody2D.velocity = new Vector2(Mathf.Clamp(playerRigidbody2D.velocity.x, -speed, +speed), playerRigidbody2D.velocity.y);
      
    }
}
