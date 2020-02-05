using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{
    public int health = 100;
    private int curHealth;

    Vector2 movement;
    Shooting shooting;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = health;
        shooting = GetComponent<Shooting>();
    }
    //Death logic
    public void TakeDamage(int damage)
    {
        curHealth = curHealth - damage;
        if (curHealth <= 0)
            Die();
    }
    private void Die()
    {
        Destroy(this.gameObject);
        //Restart Game
        GameManager.instance.RestartGame();
    }

    private void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Aim(mousePos);
        Move(new Vector2(movement.x, movement.y));

        

        
    }
}
