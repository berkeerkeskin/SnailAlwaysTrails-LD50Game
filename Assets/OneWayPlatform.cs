using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    public bool isUp;

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            isUp = true;
            if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W))
            {
                transform.parent.GetComponent<Collider2D>().enabled = false;
            }else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
            {
                transform.parent.GetComponent<Collider2D>().enabled = true;
            }
        }
    }
}
