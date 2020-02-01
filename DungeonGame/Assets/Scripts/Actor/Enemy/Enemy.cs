using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;
using Pathfinding;

public class Enemy : MonoBehaviour
{

    public int health;
    private int curHealth;




    private void Start()
    {

        StartCoroutine(SpawnEffect());


        GetComponent<AIPath>().isStopped = true;



        curHealth = health;
    }

    public void TakeDamage(int damage)
    {
        curHealth = curHealth - damage;
        if (curHealth <= 0)
        {
            Die();
            //TODO Explode Effect
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }

    private IEnumerator SpawnEffect()
    {
        ParticleSystem particles = GetComponentInChildren<ParticleSystem>();
        particles.Play();
        yield return new WaitForSeconds(1);
        GetComponent<AIPath>().isStopped = false;

    }


    
    
}
