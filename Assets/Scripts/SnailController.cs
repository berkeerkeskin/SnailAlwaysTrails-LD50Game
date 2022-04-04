using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        //Debug.Log(gameObject.GetComponent<Rigidbody2D>().velocity.x);
        if (directionX >= 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }else if (directionX < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        Debug.Log("speed: " + speed);
    }


    Vector3 findTarget()
    {
        targetPosition = GameObject.FindWithTag("Player").transform.position;
        return targetPosition;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "cat food")
        {
            speed -= 0.3f;
        }else if (other.tag == "cat litter")
        {
            speed -= 0.4f;
        }else if (other.tag == "cereal")
        {
            speed -= 0.3f;
        }else if (other.tag == "coffee mag")
        {
            speed -= 0.4f;
        }else if (other.tag == "cologne")
        {
            speed -= 0.2f;
        }else if (other.tag == "house")
        {
            speed -= 0.5f;
        }else if (other.tag == "ice cream")
        {
            speed += 0.2f;
        }else if (other.tag == "ice cubes")
        {
            speed += 0.5f;
        }else if (other.tag == "koli")
        {
            speed -= 0.5f;
        }else if (other.tag == "milk")
        {
            speed -= 0.2f;
        }else if (other.tag == "mirror")
        {
            speed -= 0.4f;
        }else if (other.tag == "oil")
        {
            speed += 0.3f;
        }else if (other.tag == "salt")
        {
            speed -= 0.1f;
        }else if (other.tag == "sawdust")
        {
            speed -= 0.5f;
        }else if (other.tag == "soap")
        {
            speed += 0.3f;
        }else if (other.tag == "stones")
        {
            speed -= 0.5f;
        }else if (other.tag == "water")
        {
            speed -= 0.2f;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "cat food")
        {
            speed += 0.3f;
        }else if (other.tag == "cat litter")
        {
            speed += 0.4f;
        }else if (other.tag == "cereal")
        {
            speed += 0.3f;
        }else if (other.tag == "coffee mag")
        {
            speed += 0.4f;
        }else if (other.tag == "cologne")
        {
            speed += 0.2f;
        }else if (other.tag == "house")
        {
            speed += 0.5f;
        }else if (other.tag == "ice cream")
        {
            speed -= 0.2f;
        }else if (other.tag == "ice cubes")
        {
            speed -= 0.5f;
        }else if (other.tag == "koli")
        {
            speed += 0.5f;
        }else if (other.tag == "milk")
        {
            speed += 0.2f;
        }else if (other.tag == "mirror")
        {
            speed += 0.4f;
        }else if (other.tag == "oil")
        {
            speed -= 0.3f;
        }else if (other.tag == "salt")
        {
            speed += 0.1f;
        }else if (other.tag == "sawdust")
        {
            speed += 0.5f;
        }else if (other.tag == "soap")
        {
            speed -= 0.3f;
        }else if (other.tag == "stones")
        {
            speed += 0.5f;
        }else if (other.tag == "water")
        {
            speed += 0.2f;
        }
    }
}
