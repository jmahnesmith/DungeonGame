using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalDamage : MonoBehaviour
{
    public int damage;
    private Health playerHealth;

    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }

    public void CauseDamage()
    {
        playerHealth.TakeDamage(damage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            CauseDamage();
        }
    }
}
