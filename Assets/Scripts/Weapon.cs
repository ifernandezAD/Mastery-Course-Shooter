using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private KeyCode weaponHotkey;
    [SerializeField] private float fireDelay = 0.25f;

    private float fireTimer;

    public event Action OnFire = delegate { };

    public KeyCode WeaponHotKey { get { return weaponHotkey; } }

    void Update()
    {
        fireTimer += Time.deltaTime;

        if (Input.GetButton("Fire1"))
        {
            if (CanFire())
            {
                Fire();
            }
        }
    }

    private bool CanFire()
    {
        return fireTimer >= fireDelay;
    }

    private void Fire()
    {
        fireTimer = 0;
        Debug.Log("Firing Weapon " + gameObject.name);
        OnFire();
    }
}
