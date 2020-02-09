using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 25;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Bullet" && collision.tag != "Rooms")
        {
            if(collision.tag == "Player")
            {
                collision.GetComponent<Health>().TakeDamage(damage);
            }
            else if(collision.tag == "Enemy")
            {
                collision.GetComponent<Health>().TakeDamage(damage);
            }
            
            Destroy(this.gameObject);
        }
        
    }
}
