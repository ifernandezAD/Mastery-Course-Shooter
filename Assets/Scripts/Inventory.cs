using System;
using System.Collections;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static event Action<Weapon> OnWeaponChanged = delegate { };

    [SerializeField] private Weapon[] weapons;

    private void Start()
    {
        SwithToWeapon(weapons[0]);
    }

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

        OnWeaponChanged(weaponToSwitchTo);
    }

}
