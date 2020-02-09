using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 100;
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
        curHealth = curHealth - damage;
        if (curHealth <= 0)
            Die();
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }
}
