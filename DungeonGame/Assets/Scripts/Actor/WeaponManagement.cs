using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManagement : MonoBehaviour
{
    [SerializeField] private Gun gun;
    [SerializeField] private GameObject weaponHolder;
    [SerializeField] float coolDownDuration;
    [SerializeField] bool isEnemy = false;
    [SerializeField] Vision vision;
    [SerializeField] bool canShoot = true;

    private PlayerInput playerInput;

    private void Start()
    {
        //Declare can shoot at start
        canShoot = true;
        //Declare player fire event
        if(playerInput = GetComponent<PlayerInput>())
        playerInput.OnFire += FireWeapon;
        //Declare Vision for Enemy
        if(isEnemy)
        {
            vision = GetComponentInChildren<Vision>();
        }
        //Clone the scriptable object
        var clone = Instantiate(gun);
        Initialize(clone, weaponHolder);
    }

    private void Update()
    {
        if(isEnemy)
        {
            if(vision.canSeePlayer())
            FireWeapon();
        }
    }

    public void FireWeapon()
    {
        if(canShoot)
        {
            AudioSource.PlayClipAtPoint(gun.gunSound, Camera.main.transform.position, 0.25f);
            gun.TriggerItem();
            StartCoroutine(CoolDownCoroutine(coolDownDuration));
        }
    }

    public void Initialize(Gun selectedGun, GameObject weaponHolder)
    {
        gun = selectedGun;
        coolDownDuration = gun.gunBaseCoolDown;
        gun.Initialize(weaponHolder);
        
    }

    IEnumerator CoolDownCoroutine (float coolDownTime)
    {
        canShoot = false;
        yield return new WaitForSeconds(coolDownTime);
        canShoot = true;
    }

}
