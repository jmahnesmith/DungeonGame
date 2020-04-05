using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerMovement))]
public class PlayerAudio : MonoBehaviour
{
    public AudioClip OnCanDashSound;
    public AudioClip OnDashSound;
    [Range(0, 1)]
    public float volume = 0.5f;

    //Cached Data
    PlayerMovement playerMovement;
    PlayerInput playerInput;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerMovement.OnCanDash += PlayOnCanDashSound;
        playerInput = GetComponent<PlayerInput>();
        playerInput.OnDash += PlayOnDashSound;
    }

    private void PlayOnDashSound()
    {
        if(playerMovement.canDash)
        AudioSource.PlayClipAtPoint(OnDashSound, Camera.main.transform.position, volume);
    }

    private void PlayOnCanDashSound()
    {
        AudioSource.PlayClipAtPoint(OnCanDashSound, Camera.main.transform.position, volume);
    }
}
