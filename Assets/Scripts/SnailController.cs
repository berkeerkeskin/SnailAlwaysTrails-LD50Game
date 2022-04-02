using System.Collections;
using System.Collections.Generic;
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
        transform.position = Vector3.MoveTowards(transform.position, findTarget() , speed * Time.deltaTime);
    }

    Vector3 findTarget()
    {
        targetPosition = GameObject.FindWithTag("Target").transform.position;
        return targetPosition;
    }
}
