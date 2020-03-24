using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Gun", menuName = "ScriptableObjects/RayCastGun", order = 1)]
public class RayCastGun : Gun
{
    public int gunDamage = 1;
    public float weaponRange = 50f;
    public float hitForce = 100f;
    public Color laserColor = Color.white;

    private RaycastShootTriggerable rcShoot;

    public override void Initialize(GameObject gameObject)
    {
        rcShoot = gameObject.GetComponent<RaycastShootTriggerable>();
        rcShoot.Initialize();

        rcShoot.gunDamage = gunDamage;
        rcShoot.weaponRange = weaponRange;
        rcShoot.hitForce = hitForce;
        rcShoot.laserLine.material = new Material(Shader.Find("Unlit/Color"));
        rcShoot.laserLine.material.color = laserColor;
    }

    public override void TriggerItem()
    {
        rcShoot.Fire();
    }
}
