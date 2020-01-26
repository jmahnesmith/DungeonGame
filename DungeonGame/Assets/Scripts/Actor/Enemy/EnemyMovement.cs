using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyMovement : Actor
{
    private Vector2 movementBias;
    public float biasStrength = 1f;
    public float radius = 5f;
    private float minDist = 1f;

    private Transform target;

    public bool canMove = false;
                 

    private float xDir;
    private float yDir;
    private void Start()
    {
        movementBias = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * biasStrength;
        target = FindObjectOfType<Player>().transform;
    }

    private Vector2 Avoid()
    {
        Vector2 avoidDir = Vector2.zero;


        Collider2D selfCollider = GetComponent<Collider2D>();

        //Find all colliders near enemy
        var enemies = Physics2D.OverlapCircleAll(transform.position, radius, 9).ToList();
        if (enemies.Contains(selfCollider))
        {
            enemies.Remove(selfCollider);
        }

        List<float> distances = new List<float>();
        //loop through all enemies to find distance from this enemy
        foreach (var enemy in enemies)
        {
            distances.Add(Vector2.Distance(transform.position, enemy.transform.position));
        }
        if (distances.Count != 0)
        {
            var shortestDistance = distances.Min();
            var index = distances.IndexOf(shortestDistance);
            var positionOfClosestEnemy = enemies[index].transform.position;

            if (shortestDistance < minDist)
            {
                //Steer away from nearby enemy!
                avoidDir = transform.position - positionOfClosestEnemy;
                avoidDir = avoidDir.normalized * (1 - shortestDistance / minDist);
                return avoidDir;
            }
        }


        return avoidDir;

    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            
            //Movement
            xDir = (target.position.x - transform.position.x);
            yDir = (target.position.y - transform.position.y);
            Aim(target.position);
            Move(new Vector2(xDir, yDir) + movementBias + Avoid());
        }


    }

    
}
