using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Aim(mousePos);

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Move(new Vector2(x, y));
    }
}
