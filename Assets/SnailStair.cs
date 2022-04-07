using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailStair : MonoBehaviour
{
    [SerializeField] private Transform
        floor0,
        floor1,
        floor2;

    private Transform playerTransform;
    private SnailController snail;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        snail = GameObject.FindGameObjectWithTag("snail").GetComponent<SnailController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (snail.playerFloor == 0 && snail.snailFloor == 0 && playerTransform.position.x < floor0.position.x && 
            playerTransform.position.y < floor0.position.y)
        {
            
            gameObject.GetComponent<Collider2D>().enabled = false;

        }else if (snail.playerFloor == 1 && snail.snailFloor == 1 && playerTransform.position.x > floor1.position.x && 
                  playerTransform.position.y < floor1.position.y)
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
        }else if (snail.playerFloor == 2 && snail.snailFloor == 2 && playerTransform.position.x < floor2.position.x &&
                  playerTransform.position.y < floor2.position.y)
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<Collider2D>().enabled = true;
        }
    }
}
