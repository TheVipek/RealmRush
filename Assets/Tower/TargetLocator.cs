using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] float range = 15f;
    Transform target;
    [SerializeField] ParticleSystem particle;

    void Update()
    {
        FindClosestTarget();
        AimWeapon();
        
    }
    void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach(Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position,enemy.transform.position);
            
            if(targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }
        target = closestTarget;
    }
    void AimWeapon()
    {
        if(target == null){ return; }

        float targetDistance = Vector3.Distance(transform.position,target.position);
        weapon.LookAt(target);
        if(targetDistance < range){
            ShootWeapon(true);
        }else{
            ShootWeapon(false);
        }
    }
    void ShootWeapon(bool isActive)
    {
        ParticleSystem.EmissionModule emissionModule = particle.emission;
        emissionModule.enabled = isActive;
    }
}
