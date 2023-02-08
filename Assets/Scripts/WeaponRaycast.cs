using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRaycast : WeaponComponent
{
    private RaycastHit hitInfo;

    [SerializeField] private float maxDistance = 100f;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] PooledMonoBehaviour decalPrefab;

    protected override void WeaponFired()
    {
        Ray ray = Camera.main.ViewportPointToRay(Vector3.one / 2);

        if (Physics.Raycast(ray, out hitInfo, maxDistance, layerMask))
        {
            SpawnDecal(hitInfo.point, hitInfo.normal);
        }
    }

    private void SpawnDecal(Vector3 point, Vector3 normal)
    {
        var decal = decalPrefab.Get<PooledMonoBehaviour>(point, Quaternion.LookRotation(-normal));
        decal.ReturnToPool(5f);
    }
}
