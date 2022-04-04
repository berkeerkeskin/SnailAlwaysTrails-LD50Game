using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Objects : MonoBehaviour
{
    private PlayerController _playerController;

    public GameObject trigger;
    public Sprite
        water,
        milk,
        green_vase,
        yellow_vase,
        ice_cubes,
        cologne,
        soap,
        coffee_mug,
        box,
        oil,
        cat_food,
        cat_litter,
        talaş,
        stones,
        ice_Cream,
        house,
        cereal,
        
        çerçeve;
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
                GameObject trigger_clone = Instantiate(trigger, new Vector2(transform.position.x, transform.position.y - transform.localScale.y * 0.5f) , Quaternion.Euler(0,0,0));
                trigger_clone.tag = gameObject.tag;
                if (trigger_clone.tag == "cat food") {
                    trigger_clone.GetComponent<SpriteRenderer>().sprite = cat_food;
                }else if (trigger_clone.tag == "cat litter") {
                    trigger_clone.GetComponent<SpriteRenderer>().sprite = cat_litter;
                }else if (trigger_clone.tag == "cereal")
                {
                    trigger_clone.GetComponent<SpriteRenderer>().sprite = cereal;
                }else if (trigger_clone.tag == "coffee mag")
                {
                    trigger_clone.GetComponent<SpriteRenderer>().sprite = coffee_mug;
                }else if (trigger_clone.tag == "cologne")
                {
                    trigger_clone.GetComponent<SpriteRenderer>().sprite = cologne;
                }else if (trigger_clone.tag == "house")
                {
                    trigger_clone.GetComponent<SpriteRenderer>().sprite = house;
                }else if (trigger_clone.tag == "ice cream")
                {
                    trigger_clone.GetComponent<SpriteRenderer>().sprite = ice_Cream;
                }else if (trigger_clone.tag == "ice cubes")
                {
                    trigger_clone.GetComponent<SpriteRenderer>().sprite = ice_cubes;
                }else if (trigger_clone.tag == "koli")
                {
                    trigger_clone.GetComponent<SpriteRenderer>().sprite = box;
                }else if (trigger_clone.tag == "milk")
                {
                    trigger_clone.GetComponent<SpriteRenderer>().sprite = milk;
                }else if (trigger_clone.tag == "mirror")
                {
                    trigger_clone.GetComponent<SpriteRenderer>().sprite = çerçeve;
                }else if (trigger_clone.tag == "oil")
                {
                    trigger_clone.GetComponent<SpriteRenderer>().sprite = oil;
                }else if (trigger_clone.tag == "salt")
                {
                    trigger_clone.GetComponent<SpriteRenderer>().sprite = milk;
                }else if (trigger_clone.tag == "sawdust")
                {
                    trigger_clone.GetComponent<SpriteRenderer>().sprite = talaş;
                }else if (trigger_clone.tag == "soap")
                {
                    trigger_clone.GetComponent<SpriteRenderer>().sprite = soap;
                }else if (trigger_clone.tag == "stones")
                {
                    trigger_clone.GetComponent<SpriteRenderer>().sprite = stones;
                }else if (trigger_clone.tag == "water")
                {
                    trigger_clone.GetComponent<SpriteRenderer>().sprite = water;
                }else if (trigger_clone.tag == "yellow_vase")
                {
                    trigger_clone.GetComponent<SpriteRenderer>().sprite = yellow_vase;
                }else if (trigger_clone.tag == "green_vase")
                {
                    trigger_clone.GetComponent<SpriteRenderer>().sprite = green_vase;
                }
                Destroy(gameObject);
                _playerController.isThrown = false;
            }
        }
    }
}
