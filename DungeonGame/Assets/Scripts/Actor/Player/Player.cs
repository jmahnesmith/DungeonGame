using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{
    

    Vector2 movement;


    // Start is called before the first frame update
    void Start()
    {        
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
