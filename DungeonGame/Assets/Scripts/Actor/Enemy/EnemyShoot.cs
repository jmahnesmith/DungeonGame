using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    public float bulletForce = 10f;

    private Rigidbody2D player;

    public float shootTimer = 2f;
    private float startShootTimer;



    // Start is called before the first frame update
    void Start()
    {
        startShootTimer = shootTimer;
        player = FindObjectOfType<Player>().GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ShootOnTimer();
    }

    private void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, firePoint.transform.position, Quaternion.identity);
        Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
        rb.AddForce((player.transform.position - transform.position) * bulletForce, ForceMode2D.Impulse);
    }
    private void ShootOnTimer()
    {
        //shoot
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0)
        {
            Shoot();
            shootTimer = startShootTimer;
        }
    }
}
