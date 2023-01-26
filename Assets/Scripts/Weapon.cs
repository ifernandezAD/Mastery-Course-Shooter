using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private KeyCode weaponHotkey;

    public KeyCode WeaponHotKey { get { return weaponHotkey; } }

    void Update()
    {
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
        return true;
    }

    private void Fire()
    {
        Debug.Log("Firing Weapon " + gameObject.name);
    }

   
}
