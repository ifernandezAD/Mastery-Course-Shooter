using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private KeyCode weaponHotkey;
    [SerializeField] private float fireDelay = 0.25f;

    private float fireTimer;
    private WeaponAmmo ammo;

    public event Action OnFire = delegate { };

    public KeyCode WeaponHotKey { get { return weaponHotkey; } }

    private void Awake()
    {
        ammo = GetComponent<WeaponAmmo>();
    }

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
        if (ammo != null && ammo.IsAmmoReady() == false)
            return false;

        return fireTimer >= fireDelay;
    }

    private void Fire()
    {
        fireTimer = 0;
        Debug.Log("Firing Weapon " + gameObject.name);
        OnFire();
    }
}
