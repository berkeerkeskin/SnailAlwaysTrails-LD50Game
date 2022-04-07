using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    public bool isUp;

    private GameObject player;
    private GameObject snail;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        snail = GameObject.FindGameObjectWithTag("snail");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.name == "Player")
        {
                
                if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W )  || Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) )
                {
                    transform.parent.GetComponent<Collider2D>().enabled = false;
                }//else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W ) && transform.parent.name == "floor"|| Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W) && transform.parent.name == "floor")
               // {
                //    transform.parent.GetComponent<Collider2D>().enabled = false;
                //}
                else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) )
                {
                    
                    transform.parent.GetComponent<Collider2D>().enabled = isUp;
                    
                }
            
           
        }
        
        if (other.tag == "snail")
        {
            
            if (gameObject.tag == "snailstair" && !snail.gameObject.GetComponent<SnailController>().isPlayerInFloor)
            {
                transform.GetComponent<Collider2D>().enabled = true;
            }else if (gameObject.tag == "snailstair" && snail.gameObject.GetComponent<SnailController>().isPlayerInFloor && !isUp)
            {
                transform.GetComponent<Collider2D>().enabled = false;
            }


            isUp = true;
        }    
    }
}
