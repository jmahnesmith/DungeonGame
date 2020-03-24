using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerMovement))]
public class PlayerAudio : MonoBehaviour
{
    public AudioClip OnCanDashSound;
    [Range(0, 1)]
    public float volume = 1f;

    private void Awake()
    {
        GetComponent<PlayerMovement>().OnCanDash += PlayOnCanDashSound;
    }

    private void PlayOnCanDashSound()
    {
        AudioSource.PlayClipAtPoint(OnCanDashSound, Camera.main.transform.position, volume);
    }
}
