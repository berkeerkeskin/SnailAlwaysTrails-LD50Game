using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour
{
    private PlayerController _playerController;
    // Start is called before the first frame update
    void Awake()
    {
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Thrown()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (_playerController.isThrown == true)
        {
            if (col.collider.tag == "Ground")
            {
                Destroy(gameObject);
                _playerController.isThrown = false;
            }
        }
    }
}
