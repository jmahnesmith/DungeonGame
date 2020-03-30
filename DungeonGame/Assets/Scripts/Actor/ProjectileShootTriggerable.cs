using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShootTriggerable : MonoBehaviour
{
    [HideInInspector] public GameObject projectile;                            
    public Transform bulletSpawn;                            
    [HideInInspector] public float projectileForce = 250f;                    

    public void Launch()
    {
        //Instantiate a copy of our projectile and store it in a new rigidbody variable called clonedBullet
        GameObject clonedBullet = Instantiate(projectile, bulletSpawn.position, transform.rotation) as GameObject;
        Rigidbody2D rb = clonedBullet.GetComponent<Rigidbody2D>();
        //Add force to the instantiated bullet, pushing it forward away from the bulletSpawn location, using projectile force for how hard to push it away
        rb.AddForce(bulletSpawn.transform.up * projectileForce * 100);
    }
}
