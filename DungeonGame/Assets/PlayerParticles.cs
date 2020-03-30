using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerMovement), typeof(PlayerInput))]
public class PlayerParticles : MonoBehaviour
{
    public GameObject DashParticle;
    //Cached Scripts
    PlayerMovement playerMovement;
    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        GetComponent<PlayerInput>().OnDash += PlayDashParticle;
    }

    private void PlayDashParticle()
    {
        if(playerMovement.canDash)
        Instantiate(DashParticle, transform.position, Quaternion.identity);
    }
}
