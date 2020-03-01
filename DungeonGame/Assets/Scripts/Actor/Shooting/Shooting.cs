using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform[] firePoint;
    public GameObject bulletPrefab;
    public CameraShake cameraShake;

    public AudioClip firingSound;

    public float bulletForce = 20f;
    public float fireRate = 0.5f;
    private float nextFire = 0.0f;

    private Vector2 movement;

    public bool canShoot;

    private void Start()
    {
        canShoot = false;
    }

    private void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        if (Input.GetButton("Fire1") && canShoot && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
            StartCoroutine(cameraShake.Shake(0.1f, 0.1f));
            
            PlayShootingSound();
        }
    }
    

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

    private void PlayShootingSound()
    {
        AudioSource.PlayClipAtPoint(firingSound, Camera.main.transform.position);
    }

    public void ToggleShooting()
    {
        if (!canShoot)
            canShoot = true;
        else if (canShoot)
            canShoot = false;
    }
}
