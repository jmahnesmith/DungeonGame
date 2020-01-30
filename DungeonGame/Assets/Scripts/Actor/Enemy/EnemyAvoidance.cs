using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyAvoidance : MonoBehaviour
{
    public float radius = 5f;
    private float minDist = 1f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        rb.AddForce(Avoid());
    }
}
