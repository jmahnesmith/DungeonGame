using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{

    Vector2 movement;

    Shooting shooting;

    // Start is called before the first frame update
    void Start()
    {
        shooting = GetComponent<Shooting>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Aim(mousePos);

        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Fire1"))
        {
            shooting.Shoot();
        }

    }
    private void FixedUpdate()
    {
        Move(new Vector2(movement.x, movement.y));
    }
}
