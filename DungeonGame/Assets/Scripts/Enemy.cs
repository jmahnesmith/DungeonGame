using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : Actor
{
    public Rigidbody2D player;
    public GameObject bullet;


    public Vector2 velocity;
    [Range(.1f, .5f)]
    public float maxForce = .03f;
    [Range(1f, 10f)]
    public float maxSpeed = 1f;
    [Range(1f, 10f)]
    private float neighborhoodRadius = 3f;
    float xforce;
    float yforce;

    private Vector2 Position
    {
        get
        {
            return gameObject.transform.position;
        }
        set
        {
            gameObject.transform.position = value;
        }
    }


    public float shootTimer = 2f;
    private float startShootTimer;


    private float xDir;
    private float yDir;
    

    private void Start()
    {
        startShootTimer = shootTimer;
    }

    private void Update()
    {
        //boid
        var enemyColliders = Physics2D.OverlapCircleAll(Position, neighborhoodRadius, 9);
        var enemies = enemyColliders.Select(o => o.GetComponent<Enemy>()).ToList();
        enemies.Remove(this);
        enemies.RemoveAll(item => item == null);
        if (enemies != null)
        {
            var xforce = Seperation(enemies).x;
            var yforce = Seperation(enemies).y;
        }
        


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
        Aim(rb.transform.position);
        Move(new Vector2(xDir, yDir));
        
        
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

    private Vector2 Steer(Vector2 desired)
    {
        var steer = desired - velocity;
        steer = LimitMagnitude(steer, maxForce);

        return steer;
        
    }

    private Vector2 LimitMagnitude(Vector2 baseVector, float maxMagnitude)
    {
        if (baseVector.sqrMagnitude > maxMagnitude * maxMagnitude)
        {
            baseVector = baseVector.normalized * maxMagnitude;
        }
        return baseVector;
    }

    private Vector2 Seperation(IEnumerable<Enemy> enemies)
    {
        var direction = Vector2.zero;
        enemies = enemies.Where(o => DistanceTo(o) <= neighborhoodRadius / 2);
        if (!enemies.Any()) return direction;

        foreach (var boid in enemies)
        {
            var difference = Position - boid.Position;
            direction += difference.normalized / difference.magnitude;
        }
        direction /= enemies.Count();

        var steer = Steer(direction.normalized * maxSpeed);
        return steer;
    }

    private float DistanceTo(Enemy enemy)
    {
        try {
            return Vector2.Distance(enemy.transform.position, Position);
        }
        catch
        {
            Debug.Log("Enemy -" + enemy.name);
        }

        return 1.5f;
        //Debug.Log("Enemy position:" + enemy.transform.position + " Own Position:" + Position);
        
        
    }

}
