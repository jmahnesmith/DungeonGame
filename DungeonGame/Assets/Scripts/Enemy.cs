using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actor
{
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject bullet;

    public Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if(Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        if (timeBtwShots <= 0)
        {
            Shoot();
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    private void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
        rb.AddForce((player.position - transform.position) * 5f, ForceMode2D.Impulse);
        timeBtwShots = startTimeBtwShots;
    }
}
