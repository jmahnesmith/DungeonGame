using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : Actor
{
    //Cached Objects
    PlayerInput playerInput;
    //Dash Params
    protected int dashCooldown;
    protected bool dashing;
    protected float dashSpeed = 15f;
    protected Vector2 dashDir;
    public int dashDuration = 35;
    protected int dashC;
    public bool canDash;
    
    Color32 _firstColor;
    Color32 _secondColor = new Color32(255, 255, 255, 255);

    private bool colorSignalDone = false;

    //Events
    public event Action OnCanDash = delegate { };

    private CameraShake cameraShake;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        cameraShake = FindObjectOfType<CameraShake>();
        _firstColor = GetComponent<SpriteRenderer>().color;

        //Subscribe to events
        playerInput.OnDash += PlayerInput_OnDash;
    }


    private void PlayerInput_OnDash()
    {
        if (canDash)
        {
            if (playerInput.Horizontal > 0)
            {
                //Dash Right
                Dash(Vector2.right.normalized);

            }
            else if (playerInput.Horizontal < 0)
            {
                //Dash Left
               
                Dash(Vector2.left.normalized);
            }
            else if (playerInput.Vertical > 0)
            {
                //Dash Up
                
                Dash(Vector2.up.normalized);
            }
            else if (playerInput.Vertical < 0)
            {
                //Dash back
                
                Dash(Vector2.down.normalized);
            }
            else
            {
                
                Dash(((Vector3)playerInput.MousePosition - transform.position).normalized);
            }
        }
    }

    


    private void Update()
    {
        Aim(playerInput.MousePosition);
        Move(new Vector2(playerInput.Horizontal, playerInput.Vertical));
                       
    }

    private void FixedUpdate()
    {
        if (dashCooldown > 0) dashCooldown--;
        else
        {
            canDash = true;
            if (!colorSignalDone)
            {
                colorSignalDone = true;
                OnCanDash();
                StartCoroutine(Flash.FlashTarget(_firstColor, _secondColor, 1f, GetComponent<SpriteRenderer>()));
            }

        }

        if (dashing)
        {
            canDash = false;
            rb.velocity = (dashDir * dashSpeed);
            dashC++;
            float r = transform.localRotation.eulerAngles.z;
            if (dashC > dashDuration)
            {
                StopDash();
            }
        }
    }
    protected void Dash(Vector2 dir)
    {
        if (dashCooldown > 0) return;

        float pen = 1;
        if ((dir.x > 0.5f || dir.x < -0.5f) && (dir.y > 0.5f || dir.y < -0.5f))
        {
            pen = 0.8f;
        }
        rb.angularVelocity = 0f;
        dashing = true;
        StartCoroutine(cameraShake.Shake(0.1f, 0.2f));
        dashDir = dir * pen;
        dashC = 0;
        dashCooldown = 100;
        colorSignalDone = false;
    }
    protected void StopDash()
    {
        dashDir = Vector2.zero;
        dashing = false;
        rb.angularVelocity = 0f;
        canDash = false;
    }
}
