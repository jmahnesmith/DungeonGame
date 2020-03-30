using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Gun", menuName = "ScriptableObjects/ProjectileGun", order = 2)]
public class ProjectileGun : Gun
{
    public float projectileForce;
    public GameObject projectilePrefab;
    public float damage;
    public float coolDownTime;
    public bool CanShoot { get; private set; }

    private ProjectileShootTriggerable launcher;
    public override void Initialize(GameObject gameObject)
    {
        launcher = gameObject.GetComponent<ProjectileShootTriggerable>();
        launcher.projectileForce = projectileForce;
        launcher.projectile = projectilePrefab;
        
    }

    public override void TriggerItem()
    {
        launcher.Launch();
    }
}
