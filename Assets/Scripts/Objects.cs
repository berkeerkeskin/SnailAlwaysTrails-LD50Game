using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Objects : MonoBehaviour
{
    private PlayerController _playerController;

    public GameObject trigger;
    // Start is called before the first frame update
    void Awake()
    {
        trigger = PrefabUtility.LoadPrefabContents("Assets/Prefabs/Snail Trigger.prefab");
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
                GameObject trigger_clone = Instantiate(trigger, transform.position, Quaternion.Euler(0,0,0));
                trigger_clone.tag = gameObject.tag;
                Destroy(gameObject);
                _playerController.isThrown = false;
            }
        }
    }
}
