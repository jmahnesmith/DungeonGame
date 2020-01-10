using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Actor
{

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Aim(mousePos);

        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

    }
    private void FixedUpdate()
    {
        Move(new Vector2(movement.x, movement.y));
    }
}
