using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyMovement : Actor
{
    private Vector2 movementBias;
    public float biasStrength = 1f;
    

    private Transform target;

    public bool canMove = false;
                 

    private float xDir;
    private float yDir;
    private void Start()
    {
        movementBias = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * biasStrength;
        target = FindObjectOfType<Player>().transform;
    }


    private void FixedUpdate()
    {
        if (canMove)
        {
            
            //Movement
            xDir = (target.position.x - transform.position.x);
            yDir = (target.position.y - transform.position.y);
            Aim(target.position);
            //Move(new Vector2(xDir, yDir) + movementBias + Avoid());
        }


    }

    
}
