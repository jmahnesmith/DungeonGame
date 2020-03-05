using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 100;
    public AudioClip deathNoise;
    private int curHealth;
    public float invincibleTime = 0;
    private bool invincible = false;


    // Start is called before the first frame update
    void Start()
    {
        curHealth = health;
    }


    public void TakeDamage(int damage)
    {
        if(!invincible)
        {
            curHealth = curHealth - damage;
            invincible = true;
            StartCoroutine(ToggleInvincible());
        }
        
        if (curHealth <= 0)
            Die();
    }

    private IEnumerator ToggleInvincible()
    {
        invincible = true;
        yield return new WaitForSeconds(invincibleTime);
        invincible = false;
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
