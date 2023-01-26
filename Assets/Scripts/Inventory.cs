using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Weapon[] weapons;

    void Update()
    {
        foreach (var weapon in weapons)
        {
            if (Input.GetKeyDown(weapon.WeaponHotKey))
            {
                SwithToWeapon(weapon);
                break;
            }
        }
    }

    private void SwithToWeapon(Weapon weaponToSwitchTo)
    {
        foreach (var weapon in weapons)
        {
            weapon.gameObject.SetActive(weapon == weaponToSwitchTo);
        }
    }
}
