using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailController : MonoBehaviour
{
    private Rigidbody2D snailRigidbody2D;
    private CircleCollider2D snailCollider2D;
    public float speed = 1f;
    
    public Rigidbody2D targetRigidbody2D;
    private Vector3 targetPosition;

    void Start()
    {
        snailCollider2D = GetComponent<CircleCollider2D>();
        snailRigidbody2D = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
      
        
        
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, findTarget() , speed * Time.fixedDeltaTime);
      
        float directionX = (gameObject.transform.position.x - findTarget().x) * -1f;
        Debug.Log(gameObject.GetComponent<Rigidbody2D>().velocity.x);
        if (directionX >= 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }else if (directionX < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }


    Vector3 findTarget()
    {
        targetPosition = GameObject.FindWithTag("Player").transform.position;
        return targetPosition;
    }
}
