using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class groundScript : MonoBehaviour
{   
    
    [SerializeField]private OneWayPlatform stairs_script;

    [SerializeField] private GameObject stairs_object;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            transform.parent.GetComponent<Collider2D>().enabled = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && stairs_script.isUp && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A) ||
            other.tag == "Player" && stairs_script.isUp && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D)
           )
        {
            transform.parent.GetComponent<Collider2D>().enabled = false;
            stairs_object.GetComponent<Collider2D>().enabled = true;
        }
    }
}
