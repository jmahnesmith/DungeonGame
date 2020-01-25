using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : Actor
{
    public Rigidbody2D player;
    public GameObject bullet;
    public Transform firePoint;
    public float bulletForce = 10f;

    private float minDist = 1f;


    public float shootTimer = 2f;
    private float startShootTimer;


    private float xDir;
    private float yDir;
    private Vector2 movementBias;

    public float biasStrength = 1f;
    public float radius = 5f;

    private void Start()
    {
        movementBias = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * biasStrength;

        startShootTimer = shootTimer;
        
    }

    private void Update()
    {
        

        //shoot
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0)
        {
            Shoot();
            shootTimer = startShootTimer;
        }
        
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
        foreach(var enemy in enemies)
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
        //Movement
        xDir = (player.transform.position.x - transform.position.x);
        yDir = (player.transform.position.y - transform.position.x);
        Aim(player.transform.position);
        Move(new Vector2(xDir, yDir) + movementBias + Avoid());
        
    }
    private void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, firePoint.transform.position, Quaternion.identity);
        Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
        rb.AddForce((player.transform.position - transform.position) * bulletForce, ForceMode2D.Impulse);
    }
}
