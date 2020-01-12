using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceField : MonoBehaviour
{

    Rigidbody2D rb;
    CircleCollider2D circle;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        circle = GetComponent<CircleCollider2D>();
        circle.radius = Random.Range(0.5f, 2f);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

}
