using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }
    public Vector2 MousePosition { get; private set; }
    public bool Dash { get; private set; }
    public bool FireWeapons { get; private set; }

    public event Action OnFire = delegate { };
    public event Action OnDash = delegate { };

    private void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
        MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        FireWeapons = Input.GetButton("Fire1");
        Dash = Input.GetKeyDown(KeyCode.Space);
        if (FireWeapons)
            OnFire();
        if (Dash)
            OnDash();
    }
}
