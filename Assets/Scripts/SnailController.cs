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

    private Transform[] teleport_enter_array;
    private Transform[] teleport_exit_array;
    
    [SerializeField] private Transform
        portal_01,
        portal_11,
        portal_12,
        portal_22,
        portal_23,
        portal_33;
    void Start()
    {
        snailCollider2D = GetComponent<CircleCollider2D>();
        snailRigidbody2D = GetComponent<Rigidbody2D>();
        //enter array
        teleport_enter_array = new Transform[3];
        teleport_enter_array[0] = portal_01;
        teleport_enter_array[1] = portal_12;
        teleport_enter_array[2] = portal_23;
        
        //exit array
        teleport_exit_array = new Transform[3];
        teleport_exit_array[0] = portal_11;
        teleport_exit_array[1] = portal_22;
        teleport_exit_array[2] = portal_33;
    }

    // Update is called once per frame
    void Update()
    {
        
        targetPosition = findTarget();
     //   Debug.Log("player floor" + playerFloor + " snail " + snailFloor + " isplayer " + isPlayerInFloor);
     //Debug.Log(speed);
    }

    private void FixedUpdate()
    {
        
        if (targetPosition.y > GameObject.Find("portal_01").transform.position.y && targetPosition.y < GameObject.Find("portal_12").transform.position.y)
        {
            playerFloor = 1;
        }
        else if (targetPosition.y > GameObject.Find("portal_12").transform.position.y && targetPosition.y< GameObject.Find("portal_23").transform.position.y)
        {
            playerFloor = 2;
        }
        else if (targetPosition.y > GameObject.Find("portal_23").transform.position.y)
        {
            playerFloor = 3;
        }
        else
        {
            playerFloor = 0;
        }
        
        
        if (transform.position.y > GameObject.Find("portal_01").transform.position.y && transform.position.y < GameObject.Find("portal_12").transform.position.y)
        {
            snailFloor = 1;
        }
        else if (transform.position.y > GameObject.Find("portal_12").transform.position.y && transform.position.y < GameObject.Find("portal_23").transform.position.y)
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
        
        if (snailFloor != playerFloor)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, teleport_enter_array[snailFloor].position , speed * Time.fixedDeltaTime);
            //Debug.Log(speed * Time.fixedDeltaTime);
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
    
    Vector3 findTarget()
    {
        targetPosition = GameObject.FindWithTag("Player").transform.position;
        return targetPosition;
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "snailstair")
        {
            //Debug.Log(speed);
            speed = 1f;
        }
        
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.name == "Up")
        {
            speed = 1f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "portal_01")
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            gameObject.transform.position = teleport_exit_array[0].position;
        }
        if (other.gameObject.name == "portal_12")
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            gameObject.transform.position = teleport_exit_array[1].position;
        }
        if (other.gameObject.name == "portal_23")
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            gameObject.transform.position = teleport_exit_array[2].position;
        }
        
        if (other.tag == "cat food")
        {
            speed -= 0.4f;
        }else if (other.tag == "cat litter")
        {
            speed -= 0.4f;
        }else if (other.tag == "cereal")
        {
            speed -= 0.3f;
        }else if (other.tag == "coffee mag")
        {
            speed -= 0.5f;
        }else if (other.tag == "cologne")
        {
            speed -= 0.7f;
        }else if (other.tag == "house")
        {
            speed -= 0.5f;
        }else if (other.tag == "ice cream")
        {
            speed += 0.4f;
        }else if (other.tag == "ice cubes")
        {
            speed += 0.7f;
        }else if (other.tag == "koli")
        {
            speed -= 0.5f;
        }else if (other.tag == "milk")
        {
            speed -= 0.3f;
        }else if (other.tag == "mirror")
        {
            speed -= 0.4f;
        }else if (other.tag == "oil")
        {
            speed += 0.8f;
        }else if (other.tag == "salt")
        {
            speed -= 0.7f;
        }else if (other.tag == "sawdust")
        {
            speed -= 0.5f;
        }else if (other.tag == "soap")
        {
            speed += 0.7f;
        }else if (other.tag == "stones")
        {
            speed -= 0.5f;
        }else if (other.tag == "water")
        {
            speed -= 0.4f;
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
            speed += 0.4f;
        }else if (other.tag == "cat litter")
        {
            speed += 0.4f;
        }else if (other.tag == "cereal")
        {
            speed += 0.3f;
        }else if (other.tag == "coffee mag")
        {
            speed += 0.5f;
        }else if (other.tag == "cologne")
        {
            speed += 0.7f;
        }else if (other.tag == "house")
        {
            speed += 0.5f;
        }else if (other.tag == "ice cream")
        {
            speed -= 0.4f;
        }else if (other.tag == "ice cubes")
        {
            speed -= 0.7f;
        }else if (other.tag == "koli")
        {
            speed += 0.5f;
        }else if (other.tag == "milk")
        {
            speed += 0.3f;
        }else if (other.tag == "mirror")
        {
            speed += 0.4f;
        }else if (other.tag == "oil")
        {
            speed -= 0.8f;
        }else if (other.tag == "salt")
        {
            speed += 0.7f;
        }else if (other.tag == "sawdust")
        {
            speed += 0.5f;
        }else if (other.tag == "soap")
        {
            speed -= 0.7f;
        }else if (other.tag == "stones")
        {
            speed += 0.5f;
        }else if (other.tag == "water")
        {
            speed += 0.4f;
        }else if (other.tag == "green_vase")
        {
            speed += 0.3f;
        }else if (other.tag == "yellow_vase")
        {
            speed += 0.3f;
        }
    }
}
