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


    
    
}
