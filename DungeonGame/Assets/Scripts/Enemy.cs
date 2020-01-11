using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actor
{
    public Rigidbody2D player;
    public GameObject bullet;
    public float shootTimer = 2f;
    private float startShootTimer;

    private void Start()
    {
        startShootTimer = shootTimer;
    }

    private void Update()
    {
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0)
        {
            Shoot();
            shootTimer = startShootTimer;
        }
        
    }

    private void FixedUpdate()
    {
        Aim(rb.transform.position);
        Move(new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y));
        
        
    }

    private void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
        rb.AddForce((player.transform.position - transform.position) * 5f, ForceMode2D.Impulse);
    }
    
}
