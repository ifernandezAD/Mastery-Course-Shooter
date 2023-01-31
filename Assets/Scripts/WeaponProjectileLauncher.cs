using System;
using UnityEngine;

public class WeaponProjectileLauncher : WeaponComponent
{

    [SerializeField] private Rigidbody projectilePrefab;
    [SerializeField] private float velocity = 40f;

    private RaycastHit hitInfo;
    [SerializeField] private float maxDistance = 100f;
    [SerializeField] private LayerMask layerMask;

    protected override void WeaponFired()
    {
        Vector3 direction = GetDirection();

        var projectile = Instantiate(projectilePrefab, transform.position, Quaternion.Euler(direction));
        projectile.velocity = direction * velocity;
    }

    private Vector3 GetDirection()
    {
        var ray = Camera.main.ViewportPointToRay(Vector3.one / 2f);
        Vector3 target = ray.GetPoint(300);

        if (Physics.Raycast(ray, out hitInfo, maxDistance, layerMask))
        {
            target = hitInfo.point;
        }

        Vector3 direction = target - transform.position;
        direction.Normalize();

        return direction;

    }
}
