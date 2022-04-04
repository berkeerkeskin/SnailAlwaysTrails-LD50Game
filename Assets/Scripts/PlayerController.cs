using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using UnityEngine.IO;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float
        rayDistance,
        checkRadius,
        moveSpeed;

     [SerializeField] private float
        jumpTime,
        jumpForce;

     private float throwSpeed = 15f,
        maxMoveSpeed = 10f,
        baseMoveSpeed = 0.7f,
        acceleration = 1f,
        jumpTimeCounter;

    private bool
        isGrabbed,
        isJumping;

    public bool
        isGrounded,
        isThrown;
    [SerializeField]
    private Transform 
        grabPoint,
        rayPoint,
        feetPosition;
    
    [SerializeField]
    private LayerMask whatIsGround;

    private GameObject grabbedObject;
    public Animator animator;
    private int layerIndex;
    void Start()
    {
        Debug.Log("Start");
        rb = gameObject.GetComponent<Rigidbody2D>();
        layerIndex = LayerMask.NameToLayer("Objects");
        Debug.Log("layer of interactable objects: " + layerIndex);
        moveSpeed = baseMoveSpeed;
    }

    private void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(moveSpeed));
        animator.SetBool("isGrabbed", isGrabbed);
        //Jump();
        Grab();
        Throw();
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

    private void Grab()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, transform.up, rayDistance);
        //Debug.Log(hitInfo.collider.name);
        if (hitInfo.collider != null && hitInfo.collider.gameObject.layer == layerIndex)
        {
            //Debug.Log(hitInfo.collider.gameObject.layer);
            //Debug.Log("isGrabbed: " + isGrabbed);
            //grabbing object
            
            if (Input.GetKeyDown(KeyCode.E) && grabbedObject == null && isGrabbed == false)
            {
                isGrabbed = true;
                grabbedObject = hitInfo.collider.gameObject;
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                grabbedObject.transform.position = grabPoint.position;
                grabbedObject.transform.SetParent(transform);
            } 
        }else if (hitInfo.collider == null && grabbedObject != null && isGrabbed == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
                grabbedObject.transform.SetParent(null);
                grabbedObject = null;
                isGrabbed = false;
            }
        }
        Debug.DrawRay(rayPoint.position, transform.up * rayDistance);
    }

    private void Throw()
    {
        float directionX = Input.GetAxisRaw("Horizontal");
        if (grabbedObject != null && isGrabbed == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                isThrown = true;
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
                grabbedObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                grabbedObject.GetComponent<Rigidbody2D>().AddForce(new Vector2( throwSpeed * directionX, -throwSpeed/2), ForceMode2D.Impulse);
                grabbedObject.transform.SetParent(null);
                grabbedObject = null;
                isGrabbed = false;
            }
        }
    }

}
