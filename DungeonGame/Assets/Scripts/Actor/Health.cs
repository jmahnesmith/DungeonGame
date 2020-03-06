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


    float colorDuration = 0.5f;
    bool _changingColor = false;
    Color32 _firstColor;
    Color32 _secondColor = new Color32(255, 255, 255, 255);
    private SpriteRenderer _sprite;


    // Start is called before the first frame update
    void Start()
    {
        curHealth = health;
        _firstColor = GetComponent<SpriteRenderer>().color;
        _sprite = gameObject.GetComponent<SpriteRenderer>();
    }


    public void TakeDamage(int damage)
    {
        if(!invincible)
        {
            StartCoroutine(Flash(_sprite, _firstColor, _secondColor, colorDuration));
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

    private IEnumerator Flash(SpriteRenderer sprite, Color32 firstColor, Color32 secondColor, float duration)
    {
        _changingColor = true;
        float counter = 0;
        while (counter < duration)
        {
            counter += Time.deltaTime;

            sprite.color = Color32.Lerp(firstColor, secondColor, (counter / 2) / (duration / 2));
            sprite.color = Color32.Lerp(secondColor, firstColor, (counter / 2) / (duration / 2));

            yield return null;
        }


        _changingColor = false;
    }
}
