using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Gun", menuName = "ScriptableObjects/Gun", order = 1)]
public class Gun : Item
{
    public GameObject bulletPrefab;
    public float fireForce;
    public float damage;
    public float coolDownTime;
    public bool CanShoot { get; private set; }
    public void FireGun(Vector2 position)
    {
        GameObject bullet = Instantiate(bulletPrefab, position, Quaternion.identity);
        if (bullet.GetComponent<Rigidbody2D>())
        {
            bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.up * fireForce);
        }
        else
        {
            bullet.AddComponent<Rigidbody2D>();
            bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.up * fireForce);
        }
    }
}
