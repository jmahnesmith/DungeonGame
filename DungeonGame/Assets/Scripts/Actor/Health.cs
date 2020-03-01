using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 100;
    public AudioClip deathNoise;
    private int curHealth;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        //ParticleManager.Instance.PlayParticle(this.gameObject.transform.position, ParticleManager.ParticleEnum.HitParticleSmall);
        curHealth = curHealth - damage;
        if (curHealth <= 0)
            Die();
    }

    private void Die()
    {
        //Play Particle effect.
        ParticleManager.Instance.PlayParticle(this.gameObject.transform.position, ParticleManager.ParticleEnum.ExplosionParticle1);
        //Play Sound Effect.
        AudioSource.PlayClipAtPoint(deathNoise, Camera.main.transform.position, 1f);
        //Check if gameobject has parent 
        if(transform.parent)
        {
            Destroy(transform.parent.gameObject);
        }
        else
        Destroy(this.gameObject);
    }
}
