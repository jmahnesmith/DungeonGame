using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform[] firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    public void Shoot()
    {
        for (int i = 0; i < firePoint.Length; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint[i].position, firePoint[i].rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            rb.AddForce(firePoint[i].up * bulletForce, ForceMode2D.Impulse);

            Destroy(bullet, 10f);
        }
        

        
    }
}
