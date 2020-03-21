using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletVolume = 10f;
    public float damage = 25f;
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
            
            AudioSource.PlayClipAtPoint(explosionSound.clip, Camera.main.transform.position, bulletVolume);
            if(collision.tag == "Enemy")
            {
                collision.GetComponent<Health>().TakeDamage(damage);
                ParticleManager.Instance.PlayParticle(transform.position, ParticleManager.ParticleEnum.HitParticleSmall);
            }
            gameObject.SetActive(false);
            Invoke("DestroyObject", 2f);
        }
        
    }

    private void GetCollisionPosition(Collider2D collision)
    {
        
    }
    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
