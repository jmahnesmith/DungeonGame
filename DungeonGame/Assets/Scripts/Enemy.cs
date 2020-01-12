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
    

    public float shootTimer = 2f;
    private float startShootTimer;


    private float xDir;
    private float yDir;
    private Vector2 movementBias;
    private float biasStrength = 4f;
    
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

    private void FixedUpdate()
    {
        xDir = (player.transform.position.x - transform.position.x);
        yDir = (player.transform.position.y - transform.position.x);
        Aim(player.transform.position);
        Move(new Vector2(xDir, yDir) + movementBias);
    }

    private void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
        rb.AddForce((player.transform.position - transform.position) * 5f, ForceMode2D.Impulse);
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        xDir = -xDir;
        yDir = -yDir;
    } */


}
