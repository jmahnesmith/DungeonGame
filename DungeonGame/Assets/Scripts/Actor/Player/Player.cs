using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{
    

    Vector2 movement;


    protected int dashCooldown;
    protected bool dashing;
    protected float dashSpeed = 15f;
    protected Vector2 dashDir;
    public int dashDuration = 35;
    protected int dashC;
    public bool canDash;
    public AudioClip CanDashSound;

    float colorDuration = 5;
    float smoothness = 0.02f;
    bool _changingColor = false;
    Color32 _firstColor = new Color32(255, 176, 52, 255);
    Color32 _secondColor = new Color32(255, 255, 255, 255);

    private bool colorSignalDone = false;


    private CameraShake cameraShake;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cameraShake = FindObjectOfType<CameraShake>();
    }


    private void Update()
    {

        

        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Aim(mousePos);
        Move(new Vector2(movement.x, movement.y));

        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Dash(((Vector3)mousePos - transform.position).normalized);
        }
    }

    private void FixedUpdate()
    {
        if (dashCooldown > 0) dashCooldown--;
        else
        {
            canDash = true;
            if(!colorSignalDone)
            {
                colorSignalDone = true;
                StartCoroutine(OnCanDash(_firstColor, _secondColor, 1f));
                
            }
            
        }
            
        if (dashing)
        {
            rb.velocity = (dashDir * dashSpeed);
            dashC++;
            float r = transform.localRotation.eulerAngles.z;
            if(dashC >dashDuration)
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


    private IEnumerator OnCanDash(Color32 firstColor, Color32 secondColor, float duration)
    {
        if(canDash)
        {
            if(_changingColor)
            {
                yield break;
            }
            _changingColor = true;
            SpriteRenderer sprite = GetComponent<SpriteRenderer>();
            float counter = 0;
            AudioSource.PlayClipAtPoint(CanDashSound, Camera.main.transform.position, 0.4f);
            while (counter < duration)
            {
                counter += Time.deltaTime;
                
                sprite.color = Color32.Lerp(firstColor, secondColor, (counter / 2) / (duration / 2));
                sprite.color = Color32.Lerp(secondColor, firstColor, (counter / 2) / (duration / 2));

                yield return null;
            }

            
            _changingColor = false;
                
        }
    }
    
}
