using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
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
            if(collision.tag == "Walls")
            {
                ParticleManager.Instance.PlayParticle(transform.position, ParticleManager.ParticleEnum.HitParticleSmall);
            }
            
            AudioSource.PlayClipAtPoint(explosionSound.clip, Camera.main.transform.position);
            if (collision.tag == "Player")
            {
                collision.GetComponent<Health>().TakeDamage(damage);
                ParticleManager.Instance.PlayParticle(transform.position, ParticleManager.ParticleEnum.HitParticleSmall);
            }
            gameObject.SetActive(false);
            Invoke("DestroyObject", 2f);
        }
        
    }
    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
