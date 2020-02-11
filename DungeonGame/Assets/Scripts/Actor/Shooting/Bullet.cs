using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 25;
    private AudioSource explosionSound;

    private void Awake()
    {
        explosionSound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag != "Bullet" && collision.tag != "Rooms")
        {
            AudioSource.PlayClipAtPoint(explosionSound.clip, Camera.main.transform.position);
            if (collision.tag == "Player")
            {
                collision.GetComponent<Health>().TakeDamage(damage);
            }
            else if(collision.tag == "Enemy")
            {
                collision.GetComponent<Health>().TakeDamage(damage);
            }
            gameObject.active = false;
            Invoke("DestroyObject", 2f);
        }
        
    }
    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
