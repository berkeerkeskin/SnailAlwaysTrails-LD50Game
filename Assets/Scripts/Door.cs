using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator animator;
    private Collider2D boxCollider2D;
    private Collider2D playerCollider;
    private GameObject player;
    
    private bool isPlayerNear;
    private bool isOpen;
    // Start is called before the first frame update
    private void Awake()
    {
        boxCollider2D = GetComponent<Collider2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<CapsuleCollider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isPlayerNear && gameObject.tag == "lock_door" && player.GetComponent<PlayerController>().isKeyCollected)
        {
            animator.SetTrigger("isOpened");
            isOpen = true;
            Destroy(boxCollider2D);
        } else if (Input.GetKeyDown(KeyCode.F) && isPlayerNear && gameObject.tag == "Door")
        {
            Debug.Log("F pressed");
            animator.SetTrigger("isOpened");
            isOpen = true;
            Destroy(boxCollider2D);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            Debug.Log("Press F");
            isPlayerNear = true;

        }
        else
        {
            isPlayerNear = false;
        }
    }

    private void Open()
    {
        
    }

    private void Close()
    {
        
    }
}
