using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;
using Pathfinding;

public class Enemy : MonoBehaviour
{

    private void Start()
    {

        StartCoroutine(SpawnEffect());
        

    }


    private IEnumerator SpawnEffect()
    {
        ParticleSystem particles = GetComponentInChildren<ParticleSystem>();
        particles.Play();
        yield return new WaitForSeconds(1);

    }

    private void resetSpawn()
    {
        Vector2 currPosition = transform.position;
        Instantiate(this.gameObject, currPosition + new Vector2(1, 0), Quaternion.identity);
        Destroy(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Wall")
        {
            resetSpawn();
        }
    }




}
