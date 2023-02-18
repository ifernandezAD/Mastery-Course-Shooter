using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRaycast : WeaponComponent
{
    [SerializeField] private Transform firePoint;

    private RaycastHit hitInfo;

    [SerializeField] private float maxDistance = 100f;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] PooledMonoBehaviour decalPrefab;

    protected override void WeaponFired()
    {
        Ray ray = weapon.IsInAimMode ?
            Camera.main.ViewportPointToRay(Vector3.one / 2) :
            new Ray(firePoint.position, firePoint.forward);
            

        if (Physics.Raycast(ray, out hitInfo, maxDistance, layerMask))
        {
            Health health = hitInfo.collider.GetComponent<Health>();

            if (health != null)
            {
                health.Takehit(1);
            }
            else
            {
                SpawnDecal(hitInfo.point, hitInfo.normal);
            }       
        }
    }

    private void SpawnDecal(Vector3 point, Vector3 normal)
    {
        var decal = decalPrefab.Get<PooledMonoBehaviour>(point, Quaternion.LookRotation(-normal));
        decal.ReturnToPool(5f);
    }
}
