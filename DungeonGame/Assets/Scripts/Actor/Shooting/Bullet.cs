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
            if(collision.tag == "Enemy")
            {
                collision.GetComponent<Enemy>().TakeDamage(damage);
            }
            if(collision.tag == "Player")
            {
                collision.GetComponent<Player>().TakeDamage(damage);
            }
            Destroy(this.gameObject);
        }
        
    }
}
