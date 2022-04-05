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
    public bool isPlayerInFloor;
    private int playerFloor;
    private int snailFloor;

    void Start()
    {
        snailCollider2D = GetComponent<CircleCollider2D>();
        snailRigidbody2D = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        targetPosition = findTarget();
        Debug.Log("player floor" + playerFloor + " snail " + snailFloor + " isplayer " + isPlayerInFloor);
    }

    private void FixedUpdate()
    {
        
        if (targetPosition.y > -36f)
        {
            playerFloor = 1;
        }
        else if (targetPosition.y > -24f)
        {
            playerFloor = 2;
        }
        else if (targetPosition.y > -10f)
        {
            playerFloor = 3;
        }
        else
        {
            playerFloor = 0;
        }
        
        
        if (transform.position.y > GameObject.Find("portal_01").transform.position.y)
        {
            snailFloor = 1;
        }
        else if (transform.position.y > GameObject.Find("portal_12").transform.position.y)
        {
            snailFloor = 2;
        }
        else if (transform.position.y > GameObject.Find("portal_23").transform.position.y)
        {
            snailFloor = 3;
        }
        else
        {
            snailFloor = 0;
        }

        if (snailFloor != playerFloor)
            isPlayerInFloor = false;
        
        if (snailFloor != playerFloor && snailFloor == 0)
        {
            Vector3 position = new Vector3(-80.44f, -36f, 0f);
            transform.position = Vector3.MoveTowards(transform.position, position , speed * Time.fixedDeltaTime*2);
        }
        if (snailFloor != playerFloor && snailFloor == 1)
        {
            Vector3 position = new Vector3(-82.91f, -23.3f, 0f);
            transform.position = Vector3.MoveTowards(transform.position, position , speed * Time.fixedDeltaTime);
        }
        if (snailFloor != playerFloor && snailFloor == 2)
        {
            Vector3 position = new Vector3(-80.44f, -9.41f, 0f);
            transform.position = Vector3.MoveTowards(transform.position, position , speed * Time.fixedDeltaTime);
        }
        if (snailFloor == playerFloor)
        {
            isPlayerInFloor = true;
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
        }
        
        
        
     
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.name == "snailstair")
        {
            speed = 10f;
        }

        if (col.collider.name == "portal_01")
        {
            Vector3 position = GameObject.Find("portal_11").transform.position;
            gameObject.transform.position = position;
        }
        if (col.collider.name == "portal_12")
        {
            Vector3 position = GameObject.Find("portal_22").transform.position;
            gameObject.transform.position = position;
        }
        if (col.collider.name == "portal_23")
        {
            Vector3 position = GameObject.Find("portal_33").transform.position;
            gameObject.transform.position = position;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.name == "snailstair")
        {
            speed = 1f;
        }
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
        }else if (other.tag == "green_vase")
        {
            speed -= 0.3f;
        }else if (other.tag == "yellow_vase")
        {
            speed -= 0.3f;
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
        }else if (other.tag == "green_vase")
        {
            speed += 0.3f;
        }else if (other.tag == "yellow_vase")
        {
            speed += 0.3f;
        }
    }
}
