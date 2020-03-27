using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManagement : MonoBehaviour
{
    [SerializeField] private Gun gun;
    [SerializeField] private GameObject weaponHolder;
    private float coolDownDuration;
    private float nextReadyTime;
    private float coolDownTimeLeft;

    private PlayerInput playerInput;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerInput.OnFire += FireWeapon;
        Initialize(gun, weaponHolder);
    }

    public void FireWeapon()
    {
        AudioSource.PlayClipAtPoint(gun.gunSound, Camera.main.transform.position, 0.5f);
        gun.TriggerItem();
    }

    public void Initialize(Gun selectedGun, GameObject weaponHolder)
    {
        gun = selectedGun;
        coolDownDuration = gun.gunBaseCoolDown;
        gun.Initialize(weaponHolder);
        
    }
    private void Update()
    {
        
    }
}
