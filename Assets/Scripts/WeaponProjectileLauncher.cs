using System;
using UnityEngine;

public class WeaponProjectileLauncher : WeaponComponent
{

    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private float moveSpeed = 40f;

    private RaycastHit hitInfo;
    [SerializeField] private float maxDistance = 100f;
    [SerializeField] private LayerMask layerMask;

    protected override void WeaponFired()
    {
        Vector3 direction = GetDirection();
        
        //Apaño
        Vector3 correctDirectionY = new Vector3(direction.x, direction.y + 90, direction.z);

        var projectile = projectilePrefab.Get<Projectile>(transform.position, Quaternion.Euler(direction));
        projectile.GetComponent<Rigidbody>().velocity = direction * moveSpeed;
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
