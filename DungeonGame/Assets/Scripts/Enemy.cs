using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actor
{
    public Rigidbody2D player;
    public GameObject bullet;
    public float shootTimer = 2f;
    private float startShootTimer;
    public float pushForce;


    float directionX;
    float directionY;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        directionX = player.transform.position.x - transform.position.x;
        directionY = player.transform.position.y - transform.position.y;
        Aim(rb.transform.position);
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        
        
    }

    private void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        Rigidbody2D bulletRB = newBullet.GetComponent<Rigidbody2D>();
        bulletRB.AddForce((player.transform.position - transform.position) * 5f, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            var force = transform.position - collision.transform.position;
            force.Normalize();

            GetComponent<Rigidbody2D>().AddForce(-force * pushForce);
        }
    }


}
