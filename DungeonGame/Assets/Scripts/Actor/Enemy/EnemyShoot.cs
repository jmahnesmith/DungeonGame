using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform[] firePointArray;
    public float bulletForce = 10f;

    private Rigidbody2D player;

    public float shootTimer = 2f;
    private float startShootTimer;

    public bool shootFoward;



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
        for (int i = 0; i < firePointArray.Length; i++)
        {
            GameObject newBullet = Instantiate(bullet, firePointArray[i].transform.position, Quaternion.identity);
            Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
            if(shootFoward)
            {
                rb.AddForce(firePointArray[i].up * bulletForce, ForceMode2D.Impulse);
            }
            else
            rb.AddForce((player.transform.position - transform.position) * bulletForce, ForceMode2D.Impulse);

            Destroy(newBullet, 10f);
        }
        
        
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
