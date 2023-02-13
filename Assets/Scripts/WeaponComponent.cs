﻿using UnityEngine;

public abstract class WeaponComponent : MonoBehaviour
{
    private Weapon weapon;

    protected abstract void WeaponFired();

    protected virtual void Awake()
    {
        weapon = GetComponent<Weapon>();
        weapon.OnFire += WeaponFired;
    }

    private void OnDestroy()
    {
        weapon.OnFire -= WeaponFired;
    }
}