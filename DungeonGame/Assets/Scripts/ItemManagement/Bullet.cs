using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public class Bullet : MonoBehaviour
{
    public float bulletVolume = 0.5f;
    public float damage = 1f;
    public AudioClip collisionSound;

    private void Awake()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag != "Bullet" && collision.tag != "Rooms")
        {
            if (collision.tag == "Walls")
            {
                ParticleManager.Instance.PlayParticle(transform.position, ParticleManager.ParticleEnum.HitParticleSmall);
            }

            AudioSource.PlayClipAtPoint(collisionSound, Camera.main.transform.position, bulletVolume);
            if (collision.tag == "Enemy")
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
